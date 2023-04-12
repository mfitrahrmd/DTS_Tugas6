using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DTS_Tugas6.Data;
using DTS_Tugas6.Models;
using DTS_Tugas6.Repositories;

namespace DTS_Tugas6.Controllers
{
    public class EducationController : Controller
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IUniversityRepository _universityRepository;

        public EducationController(IEducationRepository educationRepository, IUniversityRepository universityRepository)
        {
            _educationRepository = educationRepository;
            _universityRepository = universityRepository;
        }

        // GET: Education
        public IActionResult Index()
        {
            var educations = _educationRepository.FindAll();

            return View(educations);
        }

        // GET: Education/Details/5
        public IActionResult Details(int id)
        {
            var education = _educationRepository.FindOneByPk(id);

            if (education == null)
                return NotFound();

            return View(education);
        }

        // GET: Education/Create
        public IActionResult Create()
        {
            ViewData["UniversityId"] = new SelectList(_universityRepository.FindAll(), "Id", "Name");

            return View();
        }

        // POST: Education/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Major,Degree,GPA,UniversityId")] Education education)
        {
            if (ModelState.IsValid)
            {
                _educationRepository.InsertOne(education);

                return RedirectToAction(nameof(Index));
            }

            ViewData["UniversityId"] =
                new SelectList(_educationRepository.FindAll(), "Id", "Name", education.UniversityId);

            return View(education);
        }

        // GET: Education/Edit/5
        public IActionResult Edit(int id)
        {
            var education = _educationRepository.FindOneByPk(id);

            if (education == null)
                return NotFound();

            ViewData["UniversityId"] =
                new SelectList(_universityRepository.FindAll(), "Id", "Name", education.UniversityId);
            

            return View(education);
        }

        // POST: Education/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Major,Degree,GPA,UniversityId")] Education education)
        {
            if (id != education.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _educationRepository.UpdateOneByPk(id, education);

                return RedirectToAction(nameof(Index));
            }

            ViewData["UniversityId"] =
                new SelectList(_educationRepository.FindAll(), "Id", "Name", education.UniversityId);

            return View(education);
        }

        // GET: Education/Delete/5
        public IActionResult Delete(int id)
        {
            var education = _educationRepository.FindOneByPk(id);

            if (education is null)
                return NotFound();

            return View(education);
        }

        // POST: Education/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var education = _educationRepository.FindOneByPk(id);

            if (education is not null)
                _educationRepository.DeleteOneByPk(id);

            return RedirectToAction(nameof(Index));
        }
    }
}