using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZooWebsite.Data;
using ZooWebsite.Models;

namespace ZooWebsite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class employeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public employeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: employees
        public async Task<IActionResult> Index()
        {
              return View(await _context.employees.ToListAsync());
        }

        // GET: employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.employees == null)
            {
                return NotFound();
            }

            var employees = await _context.employees
                .FirstOrDefaultAsync(m => m.id == id);
            if (employees == null)
            {
                return NotFound();
            }

            return View(employees);
        }

        // GET: employees/Create
        public IActionResult Create()
        {

            var genderitems = new List<SelectListItem>();
            genderitems.Add(new SelectListItem() { Text = "Male", Value = "M" });
            genderitems.Add(new SelectListItem() { Text = "Female", Value = "F" });


            var states = new List<SelectListItem>();
            states.Add(new SelectListItem() { Text = "TX", Value = "TX" });
            states.Add(new SelectListItem() { Text = "FL", Value = "FL" });
            states.Add(new SelectListItem() { Text = "NY", Value = "NY" });


            var jobs = new List<SelectListItem>();
            jobs.Add(new SelectListItem() { Text = "Restaurants", Value = "Restaurants" });
            jobs.Add(new SelectListItem() { Text = "Gift Shop", Value = "Gift Shop" });
            jobs.Add(new SelectListItem() { Text = "Habitats", Value = "Habitats" });

            ViewBag.genderitems = genderitems;
            ViewBag.states = states;
            ViewBag.jobs = jobs;    

            return View();
        }

        // POST: employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,first_name, middle_name, last_name, birth_date, sex, address_1, city, state, zip, phone, email, job")] employees employees)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employees);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employees);
        }

        // GET: employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.employees == null)
            {
                return NotFound();
            }

            var employees = await _context.employees.FindAsync(id);
            if (employees == null)
            {
                return NotFound();
            }

            var genderitems = new List<SelectListItem>();
            genderitems.Add(new SelectListItem() { Text = "Male", Value = "M" });
            genderitems.Add(new SelectListItem() { Text = "Female", Value = "F" });


            var states = new List<SelectListItem>();
            states.Add(new SelectListItem() { Text = "TX", Value = "TX" });
            states.Add(new SelectListItem() { Text = "FL", Value = "FL" });
            states.Add(new SelectListItem() { Text = "NY", Value = "NY" });


            var jobs = new List<SelectListItem>();
            jobs.Add(new SelectListItem() { Text = "Restaurants", Value = "Restaurants" });
            jobs.Add(new SelectListItem() { Text = "Gift Shop", Value = "Gift Shop" });
            jobs.Add(new SelectListItem() { Text = "Habitats", Value = "Habitats" });

            ViewBag.genderitems = genderitems;
            ViewBag.states = states;
            ViewBag.jobs = jobs;

            return View(employees);
        }

        // POST: employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,first_name, middle_name, last_name, birth_date, sex, address_1, city, state, zip, phone, email, job")] employees employees)
        {
            if (id != employees.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employees);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!employeesExists(employees.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employees);
        }

        // GET: employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.employees == null)
            {
                return NotFound();
            }

            var employees = await _context.employees
                .FirstOrDefaultAsync(m => m.id == id);
            if (employees == null)
            {
                return NotFound();
            }

            return View(employees);
        }

        // POST: employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.employees == null)
            {
                return Problem("Entity set 'ApplicationDbContext.employees'  is null.");
            }
            var employees = await _context.employees.FindAsync(id);
            if (employees != null)
            {
                _context.employees.Remove(employees);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool employeesExists(int id)
        {
          return _context.employees.Any(e => e.id == id);
        }
    }
}
