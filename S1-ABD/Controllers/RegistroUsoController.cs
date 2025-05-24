using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using S1_ABD.Data;
using S1_ABD.DTOs;
using S1_ABD.Service;

namespace S1_ABD.Controllers;

public class RegistroUsoController : Controller
{
    private readonly RegistroUsoService _registroService;

    public RegistroUsoController(RegistroUsoService registroService)
    {
        _registroService = registroService;
    }
    
    public async Task<IActionResult> Index()
    {
        var registros = await _registroService.GetAllRegistrosAsync();
        return View(registros);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var registroUsoDTO = await _registroService.GetDropdownAsync();
        registroUsoDTO.Retirada = DateTime.Now;
        return View(registroUsoDTO);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(RegistroUsoDTO registroDto)
    {
        Console.WriteLine(registroDto.UsuariosDropdown); 
        Console.WriteLine(registroDto.MotosDropdown);

        if (ModelState.IsValid)
        {
            try
            {
                await _registroService.AddRegistroAsync(registroDto);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Erro ao adicionar registro");
            }
        }
        registroDto = await _registroService.GetDropdownAsync();
        return View(registroDto);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var registro = await _registroService.GetRegistroByIdAsync(id);
        if (registro == null)
        {
            return NotFound();
        }
        var dropdownData = await _registroService.GetDropdownAsync();
        registro.UsuariosDropdown = dropdownData.UsuariosDropdown;
        registro.MotosDropdown = dropdownData.MotosDropdown;
        return View(registro);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(RegistroUsoDTO registroDto)
    {
        if (ModelState.IsValid)
        {
            await _registroService.UpdateRegistroAsync(registroDto);
            return RedirectToAction("Index");
        }
        return View(registroDto);
    }
    
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var registro = await _registroService.GetRegistroByIdAsync(id);
        if (registro == null)
        {
            return NotFound();
        }
        return View(registro);
    }
    
    [HttpPost, ActionName("DeleteConfirmed")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _registroService.DeleteRegistroAsync(id);
        return RedirectToAction("Index");
    }
}