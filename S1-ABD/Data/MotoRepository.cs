using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using S1_ABD.Models;

namespace S1_ABD.Data;

public class MotoRepository : IMotoRepository
{
    private readonly DataContext _context;

    public MotoRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Moto>> GetAllAsync()
    {
        return await _context.Motos.ToListAsync();
    }

    public async Task<Moto> GetByIdAsync(int id)
    {
        return await _context.Motos.FindAsync(id);
    }

    public async Task AddMotoAsync(Moto moto)
    {
        Console.WriteLine("entrei no repository");
        await _context.Motos.AddAsync(moto);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateMotoAsync(Moto moto)
    {
        _context.Motos.Update(moto);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteMotoAsync(int id)
    {
        var moto = await _context.Motos.FindAsync(id);
        if (moto != null)
        {
            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Moto>> GetMotosTrueAsync()
    {
        return await _context.Motos.Where(m => m.IsUsing == true).ToListAsync();
    }
    
    public async Task<IEnumerable<SelectListItem>> GetMotosDropdownAsync()
    {
        return await _context.Motos
            .OrderBy(m => m.Placa)
            .Select(m => new SelectListItem 
            { 
                Value = m.Id.ToString(), 
                Text = m.Placa 
            })
            .AsNoTracking()
            .ToListAsync();
    }
}