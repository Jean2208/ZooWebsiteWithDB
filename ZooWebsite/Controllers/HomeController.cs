using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509.SigI;
using Org.BouncyCastle.Utilities;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using ZooWebsite.Data;
using ZooWebsite.Models;


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

        public IActionResult Tickets()
        {
            List<Items> items = new List<Items>();
            using (MySqlConnection con = new MySqlConnection("Server=database-1.csbkzbovmi4k.us-east-1.rds.amazonaws.com, 3306; Database=zoo; uid=admin; pwd=aLR*0(\\2;"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT name,price,in_stock FROM items", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Items item = new Items();
                    item.instock = Convert.ToInt32(reader["in_stock"]);
                    item.Name = reader["name"].ToString();
                    item.Price = reader["price"].ToString();
                    items.Add(item);
                }
                reader.Close();
            }

            return View(items);


        }











        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}