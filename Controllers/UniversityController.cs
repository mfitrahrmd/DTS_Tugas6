using DTS_Tugas6.Models;
using DTS_Tugas6.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DTS_Tugas6.Controllers;

public class UniversityController : Controller
{
    private readonly IUniversityRepository _universityRepository;

    public UniversityController(IUniversityRepository universityRepository)
    {
        _universityRepository = universityRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var universities = await _universityRepository.FindAll();

        return View(universities);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var university = await _universityRepository.FindOneByPk(id);

        return View(university);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(University university)
    {
        await _universityRepository.InsertOne(university);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var university = await _universityRepository.FindOneByPk(id);

        return View(university);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(int id, University university)
    {
        await _universityRepository.UpdateOneByPk(id, university);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> ConfirmDelete(int id)
    {
        var university = await _universityRepository.FindOneByPk(id);

        return View(university);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _universityRepository.DeleteOneByPk(id);

        return RedirectToAction("Index");
    }
}