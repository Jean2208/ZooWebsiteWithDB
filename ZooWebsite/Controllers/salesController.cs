using System;
using System.Collections.Generic;
using System.Dynamic;
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
    
    public class salesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public salesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Shop()
        {
            return View(await _context.items.ToListAsync());

        }

        [Authorize]

        // GET: sales/Checkout
        public IActionResult Checkout(int? id)
        {
            var product = _context.items;
            var products = new List<SelectListItem>();

            foreach (var item in product )
            {
                if (item.id == id)
                {
                    products.Add(new SelectListItem() { Text = item.name, Value = item.id.ToString() });
                }
            }

            ViewBag.products = products;

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("item_id, quantity")] sales sales)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Shop));
            }
            return View(sales);
        }
    }

}



   

        

