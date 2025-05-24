using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S1_ABD.Models;

[Table("TBL_USUARIOS")]
public class Usuario
{
    [Key]
    [Column("id_usuario")]
    public int Id { get; set; }

    [Column("nome_usuario")]
    public required string Nome { get; set; }

    [Column("cpf")]
    public required string Cpf { get; set; }

    [Column("telefone")]
    public required string Telefone { get; set; }
}