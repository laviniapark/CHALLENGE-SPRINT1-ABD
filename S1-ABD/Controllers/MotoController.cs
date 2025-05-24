using Microsoft.AspNetCore.Mvc;
using S1_ABD.DTOs;
using S1_ABD.Service;

namespace S1_ABD.Controllers;

public class MotoController : Controller
{
    private readonly MotoService _motoService;

    public MotoController(MotoService motoService)
    {
        _motoService = motoService;
    }

    public async Task<IActionResult> Index()
    {
        var motos = await _motoService.GetAllMotosAsync();
        return View(motos);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
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

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var moto = await _motoService.GetMotoByIdAsync(id);
        if (moto == null)
        {
            return NotFound();
        }
        return View(moto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(MotoDTO motoDto)
    {
        if (ModelState.IsValid)
        {
            await  _motoService.UpdateMotoAsync(motoDto);
            return RedirectToAction("Index");
        }
        return View(motoDto);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var moto = await _motoService.GetMotoByIdAsync(id);
        if (moto == null)
        {
            return NotFound();
        }
        return View(moto);
    }

    [HttpPost, ActionName("DeleteConfirmed")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _motoService.DeleteMotoAsync(id);
        return RedirectToAction("Index");
    }
}