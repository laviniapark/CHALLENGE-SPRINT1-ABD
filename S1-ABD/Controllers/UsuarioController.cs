using Microsoft.AspNetCore.Mvc;
using S1_ABD.DTOs;
using S1_ABD.Service;

namespace S1_ABD.Controllers;

public class UsuarioController : Controller
{
    private readonly UsuarioService _usuarioService;

    public UsuarioController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    public async Task<IActionResult> Index()
    {
        var usuarios = await _usuarioService.GetAllUsuariosAsync();
        return View(usuarios);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
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
    
    [HttpGet("Usuario/cpf/{cpf}")]
    public async Task<IActionResult> GetByCpf(string cpf)
    {
        var usuario = await _usuarioService.GetUsuarioByCpfAsync(cpf);

        if (usuario == null)
        {
            return NotFound();
        }

        return View(usuario);
    }


    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
        if (usuario == null)
        {
            return NotFound();
        }
        return View(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UsuarioDTO usuarioDto)
    {
        if (ModelState.IsValid)
        {
            await _usuarioService.UpdateUsuarioAsync(usuarioDto);
            return RedirectToAction("Index");
        }
        return View(usuarioDto);
    }

    [HttpGet]
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
        return RedirectToAction("Index");
    }
}