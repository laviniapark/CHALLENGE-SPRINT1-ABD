using AutoMapper;
using S1_ABD.DTOs;
using S1_ABD.Models;

namespace S1_ABD.Mapeamento;

public class RegistroUsoProfile : Profile
{
    public RegistroUsoProfile()
    {
        CreateMap<RegistroUso, RegistroUsoDTO>()
            .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom(src => src.Usuario.Id))
            .ForMember(dest => dest.MotoId, opt => opt.MapFrom(src => src.Moto.Id))
            .ReverseMap();
    }
}