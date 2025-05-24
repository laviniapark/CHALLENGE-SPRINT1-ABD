using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using S1_ABD.Models;

namespace S1_ABD.Data;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly DataContext _context;

    public UsuarioRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task<Usuario> GetByIdAsync(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    public async Task<Usuario> GetByCpfAsync(string cpf)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.Cpf.Equals(cpf));
    }
    
    public async Task AddUsuarioAsync(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateUsuarioAsync(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUsuarioAsync(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario != null)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task<IEnumerable<SelectListItem>> GetUsuariosDropdownAsync()
    {
        return await _context.Usuarios
            .OrderBy(u => u.Nome)
            .Select(u => new SelectListItem 
            { 
                Value = u.Id.ToString(), 
                Text = u.Nome 
            })
            .AsNoTracking()
            .ToListAsync();
    }
}