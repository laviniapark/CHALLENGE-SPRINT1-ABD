using System.ComponentModel.DataAnnotations;

namespace S1_ABD.Models;

public class Moto
{
    [Key]
    public int Id { get; set; }
    
    public  required string Marca { get; set; }
    
    public required string Modelo { get; set; }
    
    public required int Ano { get; set; }
    
    public required string Placa { get; set; }
    
    public bool IsUsing { get; set; }
}