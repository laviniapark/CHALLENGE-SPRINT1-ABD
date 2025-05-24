using AutoMapper;
using S1_ABD.Data;
using S1_ABD.DTOs;
using S1_ABD.Models;

namespace S1_ABD.Service;

public class RegistroUsoService
{
    private readonly IRegistroUsoRepository _registroUsoRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMotoRepository _motoRepository;
    private readonly IMapper _mapper;

    public RegistroUsoService(IRegistroUsoRepository registroUsoRepository, IUsuarioRepository usuarioRepository, IMotoRepository motoRepository,  IMapper mapper)
    {
        _registroUsoRepository = registroUsoRepository;
        _usuarioRepository = usuarioRepository;
        _motoRepository = motoRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RegistroUsoDTO>> GetAllRegistrosAsync()
    {
        var registros = await _registroUsoRepository.GetRegistrosDetalhadosAsync();
        return _mapper.Map<IEnumerable<RegistroUsoDTO>>(registros);
    }

    public async Task<RegistroUsoDTO> GetRegistroByIdAsync(int id)
    {
        var registro = await _registroUsoRepository.GetByIdAsync(id);
        return _mapper.Map<RegistroUsoDTO>(registro);
    }

    public async Task AddRegistroAsync(RegistroUsoDTO registroDto)
    {
        var registro = _mapper.Map<RegistroUso>(registroDto);
        registro.Usuario = await _usuarioRepository.GetByIdAsync(registro.UsuarioId);
        registro.Moto = await _motoRepository.GetByIdAsync(registro.MotoId);
        await _registroUsoRepository.AddRegistroAsync(registro);
    }

    public async Task UpdateRegistroAsync(RegistroUsoDTO registroDto)
    {
        var registro = _mapper.Map<RegistroUso>(registroDto);
        registro.Usuario = await _usuarioRepository.GetByIdAsync(registro.UsuarioId);
        registro.Moto = await _motoRepository.GetByIdAsync(registro.MotoId);
        await _registroUsoRepository.UpdateRegistroAsync(registro);
    }

    public async Task DeleteRegistroAsync(int id)
    {
        await _registroUsoRepository.DeleteRegistroAsync(id);
    }

    public async Task<RegistroUsoDTO> GetDropdownAsync()
    {
        return new RegistroUsoDTO()
        {
            UsuariosDropdown = await _usuarioRepository.GetUsuariosDropdownAsync(),
            MotosDropdown = await _motoRepository.GetMotosDropdownAsync()
        };
    }
}