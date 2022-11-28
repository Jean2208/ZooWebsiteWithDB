using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using ZooWebsite.Data;
using ZooWebsite.Models;
using ZooWebsite.Models.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ZooWebsite.Controllers
{
    [Authorize(Roles="Employee, Manager")]
    public class animalsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _environment;

        public animalsController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        // GET: animals
        public async Task<IActionResult> Index()
        {
            var animals = (from a in _context.animals
                           join h in _context.habitats on a.habitat_id equals h.id
                           select new AnimalsViewModel()
                           {
                               animal_name = a.animal_name,
                               id = a.id,
                               scientific_name = a.scientific_name,
                               description = a.description,
                               sex = a.sex=="F"? "Female" : "Male",
                               age = a.age,
                               habitat_name = h.habitat_name,
                               meal_time = a.meal_time,
                               meal_type = a.meal_type,
                               place_of_origin = a.place_of_origin,
                               health_records = a.health_records,
                               image_path = a.image_path


                           }).ToList();

              return View(animals);
        }

        // GET: animals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.animals == null)
            {
                return NotFound();
            }

            var animals = (from a in _context.animals
                           join h in _context.habitats on a.habitat_id equals h.id
                           where a.id == id
                           select new AnimalsViewModel()
                           {
                               animal_name = a.animal_name,
                               id = a.id,
                               scientific_name = a.scientific_name,
                               description = a.description,
                               sex = a.sex == "F" ? "Female" : "Male",
                               age = a.age,
                               habitat_name = h.habitat_name,
                               meal_time = a.meal_time,
                               meal_type = a.meal_type,
                               place_of_origin = a.place_of_origin,
                               health_records = a.health_records,
                               image_path = a.image_path


                           }).FirstOrDefault();

            if (animals == null)
            {
                return NotFound();
            }

          

            return View(animals);
        }

        // GET: animals/Create
        public IActionResult Create()
        {
            var genderitems = new List<SelectListItem>();
            genderitems.Add(new SelectListItem() { Text = "Male", Value = "M" });
            genderitems.Add(new SelectListItem() { Text = "Female", Value = "F" });

            var habitats = _context.habitats;
            var habitatitems = new List<SelectListItem>();

            foreach(var item in habitats)
            {
                habitatitems.Add(new SelectListItem() { Text = item.habitat_name, Value = item.id.ToString() });
            }

            var times = new List<SelectListItem>();
            times.Add(new SelectListItem() { Text = "8:00 AM", Value = "8:00:00" });
            times.Add(new SelectListItem() { Text = "9:00 AM", Value = "9:00:00" });
            times.Add(new SelectListItem() { Text = "10:00 AM", Value = "10:00:00" });
            times.Add(new SelectListItem() { Text = "11:00 AM", Value = "11:00:00" });
            times.Add(new SelectListItem() { Text = "12:00 PM", Value = "12:00:00" });


            var health = new List<SelectListItem>();
            health.Add(new SelectListItem() { Text = "Healthy", Value = "Healthy" });
            health.Add(new SelectListItem() { Text = "Unhealthy", Value = "Unhealthy" });


            ViewBag.genderitems = genderitems;
            ViewBag.habitatitems = habitatitems; 
            ViewBag.times = times;
            ViewBag.health = health;
            return View();
        }

        // POST: animals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create([Bind("id,animal_name,scientific_name,description,sex,age,habitat_id,meal_time,meal_type,place_of_origin,health_records, animal_image")] animals animals)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (animals.animal_image != null && animals.animal_image.Length > 0)
                    {
                        var filepath = Path.Combine(_environment.WebRootPath, "Uploads/Animals/") + animals.animal_image.FileName;
                        var savepath = "/Uploads/Animals/" + animals.animal_image.FileName;


                        using (var stream = System.IO.File.Create(filepath))
                        {
                            animals.animal_image.CopyTo(stream);
                        }

                        animals.image_path = savepath;
                    }


                    _context.Add(animals);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (SqlException )
            {
                TempData["ErrorMessage"] = "Your Error Message";
                return RedirectToAction(nameof(Index));

            }
            catch (DbException )
            {
                TempData["ErrorMessage"] = "Your Error Message";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception )
            {
                TempData["ErrorMessage"] = "Your Error Message";
                return RedirectToAction(nameof(Index));
            }
            finally
            {
                ;
            }


          
            return View(animals);
        }

        // GET: animals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.animals == null)
            {
                return NotFound();
            }

            var animals = await _context.animals.FindAsync(id);
            if (animals == null)
            {
                return NotFound();
            }

            var genderitems = new List<SelectListItem>();
            genderitems.Add(new SelectListItem() { Text = "Male", Value = "M" });
            genderitems.Add(new SelectListItem() { Text = "Female", Value = "F" });

            var habitats = _context.habitats;
            var habitatitems = new List<SelectListItem>();

            foreach (var item in habitats)
            {
                habitatitems.Add(new SelectListItem() { Text = item.habitat_name, Value = item.id.ToString() });
            }

            var times = new List<SelectListItem>();
            times.Add(new SelectListItem() { Text = "8:00 AM", Value = "8:00:00" });
            times.Add(new SelectListItem() { Text = "9:00 AM", Value = "9:00:00" });
            times.Add(new SelectListItem() { Text = "10:00 AM", Value = "10:00:00" });
            times.Add(new SelectListItem() { Text = "11:00 AM", Value = "11:00:00" });
            times.Add(new SelectListItem() { Text = "12:00 PM", Value = "12:00:00" });


            var health = new List<SelectListItem>();
            health.Add(new SelectListItem() { Text = "Healthy", Value = "Healthy" });
            health.Add(new SelectListItem() { Text = "Unhealthy", Value = "Unhealthy" });


            ViewBag.genderitems = genderitems;
            ViewBag.habitatitems = habitatitems;
            ViewBag.times = times;
            ViewBag.health = health;
            return View(animals);
        }

        // POST: animals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,animal_name,scientific_name,description,sex,age,habitat_id,meal_time,meal_type,place_of_origin,health_records, animal_image")] animals animals)
        {
            if (id != animals.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    if (animals.animal_image.Length > 0)
                    {
                        var filepath = Path.Combine(_environment.WebRootPath, "Uploads/Animals/") + animals.animal_image.FileName;
                        var savepath = "/Uploads/Animals/" + animals.animal_image.FileName;

                        using (var stream = System.IO.File.Create(filepath))
                        {
                            animals.animal_image.CopyTo(stream);
                        }
                            

                        animals.image_path = savepath;
                    }

                    _context.Update(animals);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!animalsExists(animals.id))
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
            return View(animals);
        }

        public IActionResult ErrorHandler()
        {
            return View();
        }

        // GET: animals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.animals == null)
            {
                return NotFound();
            }

            var animals = (from a in _context.animals
                           join h in _context.habitats on a.habitat_id equals h.id
                           where a.id == id
                           select new AnimalsViewModel()
                           {
                               animal_name = a.animal_name,
                               id = a.id,
                               scientific_name = a.scientific_name,
                               description = a.description,
                               sex = a.sex == "F" ? "Female" : "Male",
                               age = a.age,
                               habitat_name = h.habitat_name,
                               meal_time = a.meal_time,
                               meal_type = a.meal_type,
                               place_of_origin = a.place_of_origin,
                               health_records = a.health_records,
                               image_path = a.image_path




                           }).FirstOrDefault();

            if (animals == null)
            {
                return NotFound();
            }

            return View(animals);
        }

        // POST: animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.animals == null)
            {
                return Problem("Entity set 'ApplicationDbContext.animals'  is null.");
            }
            var animals = await _context.animals.FindAsync(id);
            if (animals != null)
            {
                _context.animals.Remove(animals);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool animalsExists(int id)
        {
          return _context.animals.Any(e => e.id == id);
        }
    }
}
