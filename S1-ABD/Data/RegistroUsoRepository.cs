using Microsoft.EntityFrameworkCore;
using S1_ABD.DTOs;
using S1_ABD.Models;

namespace S1_ABD.Data;

public class RegistroUsoRepository : IRegistroUsoRepository
{
    private readonly DataContext _context;

    public RegistroUsoRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RegistroUso>> GetAllAsync()
    {
        return await _context.RegistroUsos
            .Include(r => r.Usuario)
            .Include(r => r.Moto)
            .ToListAsync();
    }

    public async Task<RegistroUso> GetByIdAsync(int id)
    {
        return await _context.RegistroUsos.FindAsync(id);
    }

    public async Task AddRegistroAsync(RegistroUso registroUso)
    {
        await _context.RegistroUsos.AddAsync(registroUso);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRegistroAsync(RegistroUso registroUso)
    {
        _context.RegistroUsos.Update(registroUso);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRegistroAsync(int id)
    {
        var registroUso = await _context.RegistroUsos.FindAsync(id);
        if (registroUso != null)
        {
            _context.RegistroUsos.Remove(registroUso);
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task<IEnumerable<RegistroUsoDTO>> GetRegistrosDetalhadosAsync()
    {
        return await _context.RegistroUsos
            .Include(r => r.Usuario)
            .Include(r => r.Moto)
            .Select(r => new RegistroUsoDTO
            {
                Id = r.Id,
                UsuarioNome = r.Usuario.Nome,
                MotoPlaca = r.Moto.Placa,
                Retirada = r.Retirada,
                Devolucao = r.Devolucao
            })
            .ToListAsync();
    }
}
