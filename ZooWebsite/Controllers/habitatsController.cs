using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZooWebsite.Data;
using ZooWebsite.Models;

namespace ZooWebsite.Controllers
{
    public class habitatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public habitatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: habitats
        public async Task<IActionResult> Index()
        {
              return View(await _context.habitats.ToListAsync());
        }

        // GET: habitats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.habitats == null)
            {
                return NotFound();
            }

            var habitats = await _context.habitats
                .FirstOrDefaultAsync(m => m.id == id);
            if (habitats == null)
            {
                return NotFound();
            }

            return View(habitats);
        }

        // GET: habitats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: habitats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,habitat_name,description,type,daily_maintenance_costs")] habitats habitats)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habitats);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(habitats);
        }

        // GET: habitats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.habitats == null)
            {
                return NotFound();
            }

            var habitats = await _context.habitats.FindAsync(id);
            if (habitats == null)
            {
                return NotFound();
            }
            return View(habitats);
        }

        // POST: habitats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,habitat_name,description,type,daily_maintenance_costs")] habitats habitats)
        {
            if (id != habitats.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habitats);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!habitatsExists(habitats.id))
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
            return View(habitats);
        }

        // GET: habitats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.habitats == null)
            {
                return NotFound();
            }

            var habitats = await _context.habitats
                .FirstOrDefaultAsync(m => m.id == id);
            if (habitats == null)
            {
                return NotFound();
            }

            return View(habitats);
        }

        // POST: habitats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.habitats == null)
            {
                return Problem("Entity set 'ApplicationDbContext.habitats'  is null.");
            }
            var habitats = await _context.habitats.FindAsync(id);
            if (habitats != null)
            {
                _context.habitats.Remove(habitats);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool habitatsExists(int id)
        {
          return _context.habitats.Any(e => e.id == id);
        }
    }
}
