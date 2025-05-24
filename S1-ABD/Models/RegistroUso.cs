using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S1_ABD.Models;

public class RegistroUso
{
    [Key]
    public int Id { get; set; }

    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
    
    public int MotoId { get; set; }
    public Moto Moto { get; set; }
    
    public DateTime Retirada { get; set; }

    public DateTime? Devolucao { get; set; }
}