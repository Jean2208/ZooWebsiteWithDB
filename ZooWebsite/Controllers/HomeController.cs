using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Asn1.X509.SigI;
using Org.BouncyCastle.Utilities;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using ZooWebsite.Data;
using ZooWebsite.Models;
using ZooWebsite.Models.ViewModels;

namespace ZooWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        



        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public object OurAnimals()
        {
            var animals = _context.animals.ToList();
            

            return View(animals);
        }


        public IActionResult Report1()
        {
            return View();
        }

        public IActionResult Report2()
        {
            return View();
        }

        public IActionResult Report3()
        {
            return View();
        }

      

        
        

        [Authorize(Roles ="Admin")]
        public IActionResult Dashboard()
        {

            var messages = _context.message_board.ToList();
            var reverse = Enumerable.Reverse(messages).ToList();

            return View(reverse);

            
        }

       









            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}