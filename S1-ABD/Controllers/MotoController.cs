using Microsoft.AspNetCore.Mvc;
using S1_ABD.DTOs;
using S1_ABD.Service;

namespace S1_ABD.Controllers;

[Route("Moto")]
public class MotoController : Controller
{
    private readonly MotoService _motoService;

    public MotoController(MotoService motoService)
    {
        _motoService = motoService;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var motos = await _motoService.GetAllMotosAsync();
        return View(motos);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(MotoDTO motoDto)
    {
        Console.WriteLine("Entrei no controller");
        if (ModelState.IsValid)
        {
            try
            {
                await _motoService.AddMotoAsync(motoDto);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Erro ao adicionar moto");
            }
        }
        return View(motoDto);
    }

    [HttpGet("edit")]
    public async Task<IActionResult> Edit(int id)
    {
        var moto = await _motoService.GetMotoByIdAsync(id);
        if (moto == null)
        {
            return NotFound();
        }
        return View(moto);
    }

    [HttpPost("edit")]
    public async Task<IActionResult> Edit(MotoDTO motoDto)
    {
        if (ModelState.IsValid)
        {
            await _motoService.UpdateMotoAsync(motoDto);
            return RedirectToAction("Index");
        }
        return View(motoDto);
    }

    [HttpGet("delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var moto = await _motoService.GetMotoByIdAsync(id);
        if (moto == null)
        {
            return NotFound();
        }
        return View(moto);
    }

    [HttpPost("delete"), ActionName("DeleteConfirmed")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _motoService.DeleteMotoAsync(id);
        return RedirectToAction("Index");
    }
}