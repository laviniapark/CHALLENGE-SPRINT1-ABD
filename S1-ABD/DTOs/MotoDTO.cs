using System.ComponentModel.DataAnnotations;

namespace S1_ABD.DTOs;

public class MotoDTO
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "A marca é obrigatória.")]
    public string Marca { get; set; }

    [Required(ErrorMessage = "O modelo é obrigatório.")]
    public string Modelo { get; set; }
    
    [Required(ErrorMessage = "O ano de fabricação é obrigatório.")]
    public int Ano { get; set; }
    
    [Required(ErrorMessage = "O número da placa é obrigatório.")]
    public string Placa { get; set; }
    
    [Display(Name = "Em uso?")]
    public bool IsUsing { get; set; }
}