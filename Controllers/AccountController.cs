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
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public AccountController(IAccountRepository accountRepository, IEmployeeRepository employeeRepository)
        {
            _accountRepository = accountRepository;
            _employeeRepository = employeeRepository;
        }

        // GET: Account
        public IActionResult Index()
        {
            var accounts = _accountRepository.FindAll();
            
            return View(accounts);
        }

        // GET: Account/Details/5
        public IActionResult Details(string id)
        {
            var account = _accountRepository.FindOneByPk(id);
            
            if (account is null)
                return NotFound();

            return View(account);
        }

        // GET: Account/Create
        public IActionResult Create()
        {
            ViewData["EmployeeNik"] = new SelectList(_employeeRepository.FindAll(), "Nik", "FirstName");
            
            return View();
        }

        // POST: Account/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("EmployeeNik,Password")] Account account)
        {
            if (ModelState.IsValid)
            {
                _accountRepository.InsertOne(account);
                
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["EmployeeNik"] = new SelectList(_employeeRepository.FindAll(), "Nik", "FirstName", account.EmployeeNik);
            
            return View(account);
        }

        // GET: Account/Edit/5
        public IActionResult Edit(string id)
        {
            var account = _accountRepository.FindOneByPk(id);
            
            if (account is null)
                return NotFound();
            
            ViewData["EmployeeNik"] = new SelectList(_employeeRepository.FindAll(), "Nik", "FirstName", account.EmployeeNik);
            
            return View(account);
        }

        // POST: Account/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("EmployeeNik,Password")] Account account)
        {
            if (!id.Equals(account.EmployeeNik))
                return NotFound();

            if (ModelState.IsValid)
            {
                _accountRepository.UpdateOneByPk(id, account);
                
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["EmployeeNik"] = new SelectList(_employeeRepository.FindAll(), "Nik", "FirstName", account.EmployeeNik);
            
            return View(account);
        }

        // GET: Account/Delete/5
        public IActionResult Delete(string id)
        {
            var account = _accountRepository.FindOneByPk(id);
            
            if (account is null)
                return NotFound();

            return View(account);
        }

        // POST: Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var account = _accountRepository.FindOneByPk(id);

            if (account is not null)
                _accountRepository.DeleteOneByPk(id);
            
            return RedirectToAction(nameof(Index));
        }
    }
}
