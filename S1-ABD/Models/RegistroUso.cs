using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S1_ABD.Models;

[Table("TBL_REGISTROS")]
public class RegistroUso
{
    [Key]
    [Column("id_registro")]
    public int Id { get; set; }

    [Column("id_usuario")]
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }

    [Column("id_moto")]
    public int MotoId { get; set; }
    public Moto Moto { get; set; }

    [Column("dt_retirada")]
    public DateTime Retirada { get; set; }

    [Column("dt_devolucao")]
    public DateTime? Devolucao { get; set; }
}