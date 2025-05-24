using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S1_ABD.Models;

[Table("TBL_MOTOS")]
public class Moto
{
    [Key]
    [Column("id_moto")]
    public int Id { get; set; }

    [Column("marca")]
    public required string Marca { get; set; }

    [Column("modelo")]
    public required string Modelo { get; set; }

    [Column("ano")]
    public required int Ano { get; set; }

    [Column("placa")]
    public required string Placa { get; set; }

    [Column("em_uso")]
    public bool IsUsing { get; set; }
}