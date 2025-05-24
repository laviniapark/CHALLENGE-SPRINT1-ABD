using S1_ABD.DTOs;
using S1_ABD.Models;

namespace S1_ABD.Data;

public interface IRegistroUsoRepository
{
    Task<IEnumerable<RegistroUso>> GetAllAsync();
    Task<RegistroUso> GetByIdAsync(int id);
    Task AddRegistroAsync(RegistroUso registro);
    Task UpdateRegistroAsync(RegistroUso registro);
    Task DeleteRegistroAsync(int id);
    Task<IEnumerable<RegistroUsoDTO>> GetRegistrosDetalhadosAsync();
}