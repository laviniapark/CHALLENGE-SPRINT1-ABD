using System.ComponentModel.DataAnnotations;

namespace S1_ABD.Models;

public class Usuario
{
    [Key]
    public int Id { get; set; }
    
    public required string Nome { get; set; }
    
    public required string Cpf { get; set; }
    
    public required string Telefone { get; set; }
}