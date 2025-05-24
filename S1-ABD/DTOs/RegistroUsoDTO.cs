using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using S1_ABD.Models;

namespace S1_ABD.DTOs;

public class RegistroUsoDTO
{
    public int Id { get; set; }
    
    public int UsuarioId { get; set; }
    public int MotoId { get; set; }
    
    [ValidateNever]
    public string UsuarioNome { get; set; }
    
    [ValidateNever]
    public string MotoPlaca { get; set; }
    
    [Required(ErrorMessage = "Data de retirada é obrigatório")]
    [DataType(DataType.DateTime)]
    public DateTime Retirada { get; set; }
    
    [DataType(DataType.DateTime)]
    public DateTime? Devolucao { get; set; }
    
    [ValidateNever]
    public IEnumerable<SelectListItem> UsuariosDropdown { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> MotosDropdown { get; set; }
}