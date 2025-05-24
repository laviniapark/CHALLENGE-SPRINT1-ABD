using AutoMapper;
using S1_ABD.Data;
using S1_ABD.DTOs;
using S1_ABD.Models;

namespace S1_ABD.Service;

public class MotoService
{
    private readonly IMotoRepository _motoRepository;
    private readonly IMapper _mapper;

    public MotoService(IMotoRepository motoRepository, IMapper mapper)
    {
        _motoRepository = motoRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MotoDTO>> GetAllMotosAsync()
    {
        var motos = await _motoRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<MotoDTO>>(motos);
    }

    public async Task<MotoDTO> GetMotoByIdAsync(int id)
    {
        var moto = await _motoRepository.GetByIdAsync(id);
        return _mapper.Map<MotoDTO>(moto);
    }

    public async Task AddMotoAsync(MotoDTO motoDto)
    {
        var moto = _mapper.Map<Moto>(motoDto);
        moto.IsUsing = false;
        await _motoRepository.AddMotoAsync(moto);
    }

    public async Task UpdateMotoAsync(MotoDTO motoDto)
    {
        var moto = _mapper.Map<Moto>(motoDto);
        await _motoRepository.UpdateMotoAsync(moto);
    }

    public async Task DeleteMotoAsync(int id)
    {
        await _motoRepository.DeleteMotoAsync(id);
    }
}