using Microsoft.AspNetCore.Mvc.Rendering;
using S1_ABD.Models;

namespace S1_ABD.Data;

public interface IUsuarioRepository
{
    Task<IEnumerable<Usuario>> GetAllAsync();
    Task<Usuario> GetByIdAsync(int id);
    Task<Usuario> GetByCpfAsync(string cpf);
    Task AddUsuarioAsync(Usuario usuario);
    Task UpdateUsuarioAsync(Usuario usuario);
    Task DeleteUsuarioAsync(int id);
    Task<IEnumerable<SelectListItem>> GetUsuariosDropdownAsync();
}