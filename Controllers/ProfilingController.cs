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
    public class ProfilingController : Controller
    {
        private readonly IProfilingRepository _profilingRepository;
        private readonly IEducationRepository _educationRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public ProfilingController(IProfilingRepository profilingRepository, IEducationRepository educationRepository, IEmployeeRepository employeeRepository)
        {
            _profilingRepository = profilingRepository;
            _educationRepository = educationRepository;
            _employeeRepository = employeeRepository;
        }

        // GET: Profiling
        public IActionResult Index()
        {
            var profilings = _profilingRepository.FindAll();
            
            return View(profilings);
        }

        // GET: Profiling/Details/5
        public IActionResult Details(string id)
        {
            var profiling = _profilingRepository.FindOneByPk(id);
            
            if (profiling is null)
                return NotFound();

            return View(profiling);
        }

        // GET: Profiling/Create
        public IActionResult Create()
        {
            ViewData["EducationId"] = new SelectList(_educationRepository.FindAll(), "Id", "Id");
            ViewData["EmployeeNik"] = new SelectList(_employeeRepository.FindAll(), "Nik", "Nik");
            
            return View();
        }

        // POST: Profiling/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("EmployeeNik,EducationId")] Profiling profiling)
        {
            if (ModelState.IsValid)
            {
                _profilingRepository.InsertOne(profiling);
                
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["EducationId"] = new SelectList(_educationRepository.FindAll(), "Id", "Id", profiling.EducationId);
            ViewData["EmployeeNik"] = new SelectList(_employeeRepository.FindAll(), "Nik", "Nik", profiling.EmployeeNik);
            
            return View(profiling);
        }

        // GET: Profiling/Edit/5
        public IActionResult Edit(string id)
        {
            var profiling = _profilingRepository.FindOneByPk(id);
            
            if (profiling is null)
                return NotFound();
            
            ViewData["EducationId"] = new SelectList(_educationRepository.FindAll(), "Id", "Id", profiling.EducationId);
            ViewData["EmployeeNik"] = new SelectList(_employeeRepository.FindAll(), "Nik", "Nik", profiling.EmployeeNik);
            
            return View(profiling);
        }

        // POST: Profiling/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("EmployeeNik,EducationId")] Profiling profiling)
        {
            if (!id.Equals(profiling.EmployeeNik))
                return NotFound();

            if (ModelState.IsValid)
            {
                _profilingRepository.UpdateOneByPk(id, profiling);
                
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["EducationId"] = new SelectList(_educationRepository.FindAll(), "Id", "Id", profiling.EducationId);
            ViewData["EmployeeNik"] = new SelectList(_employeeRepository.FindAll(), "Nik", "Nik", profiling.EmployeeNik);
            
            return View(profiling);
        }

        // GET: Profiling/Delete/5
        public IActionResult Delete(string id)
        {
            var profiling = _profilingRepository.FindOneByPk(id);
            
            if (profiling is null)
                return NotFound();

            return View(profiling);
        }

        // POST: Profiling/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var profiling =_profilingRepository.FindOneByPk(id);

            if (profiling is not null)
                _profilingRepository.DeleteOneByPk(id);
            
            return RedirectToAction(nameof(Index));
        }
    }
}
