using Microsoft.AspNetCore.Mvc.Rendering;
using S1_ABD.Models;

namespace S1_ABD.Data;

public interface IMotoRepository
{
    Task<IEnumerable<Moto>> GetAllAsync();
    Task<Moto> GetByIdAsync(int id);
    Task AddMotoAsync(Moto moto);
    Task UpdateMotoAsync(Moto moto);
    Task DeleteMotoAsync(int id);
    Task<IEnumerable<Moto>> GetMotosTrueAsync();
    Task<IEnumerable<SelectListItem>> GetMotosDropdownAsync();
}