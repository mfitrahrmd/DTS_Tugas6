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
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET: Employee
        public IActionResult Index()
        {
            var employees = _employeeRepository.FindAll();
            
            return View(employees);
        }

        // GET: Employee/Details/5
        public IActionResult Details(string id)
        {
            var employee = _employeeRepository.FindOneByPk(id);
                
            if (employee is null)
                return NotFound();

            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nik,FirstName,LastName,Birthdate,Gender,HiringDate,Email,PhoneNumber")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.InsertOne(employee);
                
                return RedirectToAction(nameof(Index));
            }
            
            return View(employee);
        }

        // GET: Employee/Edit/5
        public IActionResult Edit(string id)
        {
            var employee = _employeeRepository.FindOneByPk(id);
            
            if (employee is null)
                return NotFound();
            
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("Nik,FirstName,LastName,Birthdate,Gender,HiringDate,Email,PhoneNumber")] Employee employee)
        {
            if (!id.Equals(employee.Nik))
                return NotFound();

            if (ModelState.IsValid)
            {
                _employeeRepository.UpdateOneByPk(id, employee);
                
                return RedirectToAction(nameof(Index));
            }
            
            return View(employee);
        }

        // GET: Employee/Delete/5
        public IActionResult Delete(string id)
        {
            var employee = _employeeRepository.FindOneByPk(id);
            
            if (employee is null)
                return NotFound();

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var employee = _employeeRepository.FindOneByPk(id);

            if (employee is not null)
                _employeeRepository.DeleteOneByPk(id);
            
            return RedirectToAction(nameof(Index));
        }
    }
}
