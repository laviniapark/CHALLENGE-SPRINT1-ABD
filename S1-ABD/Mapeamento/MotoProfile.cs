using AutoMapper;
using S1_ABD.DTOs;
using S1_ABD.Models;

namespace S1_ABD.Mapeamento;

public class MotoProfile : Profile
{
    public MotoProfile()
    {
        CreateMap<Moto, MotoDTO>().ReverseMap();
    }
}