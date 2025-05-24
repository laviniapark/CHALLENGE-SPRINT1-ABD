using AutoMapper;
using S1_ABD.DTOs;
using S1_ABD.Models;

namespace S1_ABD.Mapeamento;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<Usuario, UsuarioDTO>().ReverseMap();
    }
}