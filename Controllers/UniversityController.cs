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
    public IActionResult Index()
    {
        var universities = _universityRepository.FindAll();

        return View(universities);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var university = _universityRepository.FindOneByPk(id);

        return View(university);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(University university)
    {
        _universityRepository.InsertOne(university);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var university = _universityRepository.FindOneByPk(id);

        return View(university);
    }

    [HttpPost]
    public IActionResult Edit(int id, University university)
    {
        _universityRepository.UpdateOneByPk(id, university);

        return RedirectToAction(nameof(Index));
    }

    // GET: University/Delete/5
    public IActionResult Delete(int id)
    {
        var university = _universityRepository.FindOneByPk(id);

        if (university is null)
            return NotFound();

        return View(university);
    }

    // POST: University/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var university = _universityRepository.FindOneByPk(id);

        if (university is not null)
            _universityRepository.DeleteOneByPk(id);

        return RedirectToAction(nameof(Index));
    }
}