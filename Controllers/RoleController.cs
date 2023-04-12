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
    public class RoleController : Controller
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        // GET: Role
        public IActionResult Index()
        {
            var roles = _roleRepository.FindAll();

            return View(roles);
        }

        // GET: Role/Details/5
        public IActionResult Details(int id)
        {
            var role = _roleRepository.FindOneByPk(id);

            if (role is null)
                return NotFound();

            return View(role);
        }

        // GET: Role/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name")] Role role)
        {
            if (ModelState.IsValid)
            {
                _roleRepository.InsertOne(role);

                return RedirectToAction(nameof(Index));
            }

            return View(role);
        }

        // GET: Role/Edit/5
        public IActionResult Edit(int id)
        {
            var role = _roleRepository.FindOneByPk(id);

            if (role is null)
                return NotFound();

            return View(role);
        }

        // POST: Role/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name")] Role role)
        {
            if (!id.Equals(role.Id))
                return NotFound();

            if (ModelState.IsValid)
            {
                _roleRepository.UpdateOneByPk(id, role);

                return RedirectToAction(nameof(Index));
            }

            return View(role);
        }

        // GET: Role/Delete/5
        public IActionResult Delete(int id)
        {
            var role = _roleRepository.FindOneByPk(id);

            if (role is null)
                return NotFound();

            return View(role);
        }

        // POST: Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var role = _roleRepository.FindOneByPk(id);

            if (role is not null)
                _roleRepository.DeleteOneByPk(id);

            return RedirectToAction(nameof(Index));
        }
    }
}