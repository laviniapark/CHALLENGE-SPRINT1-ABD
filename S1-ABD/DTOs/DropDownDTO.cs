using Microsoft.AspNetCore.Mvc.Rendering;

namespace S1_ABD.DTOs;

public class DropDownDTO
{
    public IEnumerable<SelectListItem> Usuarios { get; set; }
    public IEnumerable<SelectListItem> Motos { get; set; }

}