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
    public class AccountRoleController : Controller
    {
        private readonly IAccountRoleRepository _accountRoleRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IRoleRepository _roleRepository;

        public AccountRoleController(IAccountRoleRepository accountRoleRepository, IAccountRepository accountRepository, IRoleRepository roleRepository)
        {
            _accountRoleRepository = accountRoleRepository;
            _accountRepository = accountRepository;
            _roleRepository = roleRepository;
        }

        // GET: AccountRole
        public IActionResult Index()
        {
            var accountRoles = _accountRoleRepository.FindAll();
            
            return View(accountRoles);
        }

        // GET: AccountRole/Details/5
        public IActionResult Details(int id)
        {
            var accountRole = _accountRoleRepository.FindOneByPk(id);
            
            if (accountRole is null)
                return NotFound();

            return View(accountRole);
        }

        // GET: AccountRole/Create
        public IActionResult Create()
        {
            ViewData["AccountNik"] = new SelectList(_accountRepository.FindAll(), "EmployeeNik", "EmployeeNik");
            ViewData["RoleId"] = new SelectList(_roleRepository.FindAll(), "Id", "Id");
            
            return View();
        }

        // POST: AccountRole/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,AccountNik,RoleId")] AccountRole accountRole)
        {
            if (ModelState.IsValid)
            {
                _accountRoleRepository.InsertOne(accountRole);
                
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["AccountNik"] = new SelectList(_accountRepository.FindAll(), "EmployeeNik", "EmployeeNik", accountRole.AccountNik);
            ViewData["RoleId"] = new SelectList(_roleRepository.FindAll(), "Id", "Id", accountRole.RoleId);
            
            return View(accountRole);
        }

        // GET: AccountRole/Edit/5
        public IActionResult Edit(int id)
        {
            var accountRole = _accountRoleRepository.FindOneByPk(id);
            
            if (accountRole is null)
                return NotFound();
            
            ViewData["AccountNik"] = new SelectList(_accountRepository.FindAll(), "EmployeeNik", "EmployeeNik", accountRole.AccountNik);
            ViewData["RoleId"] = new SelectList(_roleRepository.FindAll(), "Id", "Id", accountRole.RoleId);
            
            return View(accountRole);
        }

        // POST: AccountRole/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,AccountNik,RoleId")] AccountRole accountRole)
        {
            if (!id.Equals(accountRole.Id))
                return NotFound();

            if (ModelState.IsValid)
            {
                _accountRoleRepository.UpdateOneByPk(id, accountRole);
                
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["AccountNik"] = new SelectList(_accountRepository.FindAll(), "EmployeeNik", "EmployeeNik", accountRole.AccountNik);
            ViewData["RoleId"] = new SelectList(_roleRepository.FindAll(), "Id", "Id", accountRole.RoleId);
            
            return View(accountRole);
        }

        // GET: AccountRole/Delete/5
        public IActionResult Delete(int id)
        {
            var accountRole = _accountRoleRepository.FindOneByPk(id);
            
            if (accountRole is null)
                return NotFound();

            return View(accountRole);
        }

        // POST: AccountRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var accountRole = _accountRoleRepository.FindOneByPk(id);

            if (accountRole is not null)
                _accountRoleRepository.DeleteOneByPk(id);
            
            return RedirectToAction(nameof(Index));
        }
    }
}
