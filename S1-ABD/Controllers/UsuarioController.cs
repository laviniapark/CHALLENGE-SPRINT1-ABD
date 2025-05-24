using Microsoft.AspNetCore.Mvc;
using S1_ABD.DTOs;
using S1_ABD.Service;

namespace S1_ABD.Controllers;

[Route("Usuario")]
public class UsuarioController : Controller
{
    private readonly UsuarioService _usuarioService;

    public UsuarioController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var usuarios = await _usuarioService.GetAllUsuariosAsync();
        return View(usuarios);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(UsuarioDTO usuarioDto)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _usuarioService.AddUsuarioAsync(usuarioDto);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Erro ao adicionar usuario");
            }
        }
        return View(usuarioDto);
    }

    [HttpGet("cpf/{cpf}")]
    public async Task<IActionResult> GetByCpf(string cpf)
    {
        var usuario = await _usuarioService.GetUsuarioByCpfAsync(cpf);

        if (usuario == null)
        {
            return View("UsuarioNaoEncontrado");
        }

        return View(usuario);
    }


    [HttpGet("edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
        if (usuario == null)
        {
            return NotFound();
        }
        return View(usuario);
    }

    [HttpPost("edit/{id}")]
    public async Task<IActionResult> Edit(UsuarioDTO usuarioDto)
    {
        if (ModelState.IsValid)
        {
            await _usuarioService.UpdateUsuarioAsync(usuarioDto);
            return RedirectToAction("Index");
        }
        return View(usuarioDto);
    }

    [HttpGet("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
        if (usuario == null)
        {
            return NotFound();
        }
        return View(usuario);
    }

    [HttpPost, ActionName("DeleteConfirmed")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _usuarioService.DeleteUsuarioAsync(id);
        return RedirectToAction("");
    }
}