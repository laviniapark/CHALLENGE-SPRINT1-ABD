using System.ComponentModel.DataAnnotations;

namespace S1_ABD.DTOs;

public class UsuarioDTO
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Nome obrigatório")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "CPF obrigatório")]
    public string Cpf { get; set; }
    
    [Required(ErrorMessage = "Telefone obrigatório")]
    public string Telefone { get; set; }
}