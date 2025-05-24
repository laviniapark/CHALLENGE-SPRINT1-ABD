using AutoMapper;
using S1_ABD.Data;
using S1_ABD.DTOs;
using S1_ABD.Models;

namespace S1_ABD.Service;

public class UsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;

    public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
    {
        _usuarioRepository = usuarioRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UsuarioDTO>> GetAllUsuariosAsync()
    {
        var usuarios = await _usuarioRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
    }

    public async Task<UsuarioDTO> GetUsuarioByIdAsync(int id)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(id);
        return _mapper.Map<UsuarioDTO>(usuario);
    }

    public async Task<UsuarioDTO> GetUsuarioByCpfAsync(string cpf)
    {
        var usuario = await _usuarioRepository.GetByCpfAsync(cpf);
        return _mapper.Map<UsuarioDTO>(usuario);
    }

    public async Task AddUsuarioAsync(UsuarioDTO usuarioDto)
    {
        var usuario = _mapper.Map<Usuario>(usuarioDto);
        await _usuarioRepository.AddUsuarioAsync(usuario);
    }

    public async Task UpdateUsuarioAsync(UsuarioDTO usuarioDto)
    {
        var usuario = _mapper.Map<Usuario>(usuarioDto);
        await _usuarioRepository.UpdateUsuarioAsync(usuario);
    }

    public async Task DeleteUsuarioAsync(int id)
    {
        await _usuarioRepository.DeleteUsuarioAsync(id);
    }
}