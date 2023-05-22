using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using Top2000_2.Data;
using Top2000_2.Models;

namespace Top2000_2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbcontext )
        {
            _dbContext = dbcontext;
            _logger = logger;
        }

        public IActionResult Index(int jaar = 2021, string naam = "")
        {
            if (naam == "" || naam == null)
            {
                var lijst = _dbContext.VmLijst.FromSqlInterpolated($"spLijst {jaar}").ToList();
                ViewBag.filteredData = lijst;
            }
            else
            {
                var filteropnaam = _dbContext.vmFilterOpNaam.FromSqlInterpolated($"spFilterOpNaam {jaar}, {naam}").ToList();
                ViewBag.filteredData = filteropnaam;
            }
            ViewBag.jaar = jaar;
            ViewBag.Artiestnaam = naam;
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Top2000(int jaar = 2021, string naam = "") 
        {
            if (naam == "" || naam == null)
            {
                var lijst = _dbContext.VmLijst.FromSqlInterpolated($"spLijst {jaar}").ToList();
                ViewBag.filteredData = lijst;
            }
            else
            {
                var filteropnaam = _dbContext.vmFilterOpNaam.FromSqlInterpolated($"spFilterOpNaam {jaar}, {naam}").ToList();
                ViewBag.filteredData = filteropnaam;
            }
            ViewBag.jaar = jaar;
            ViewBag.Artiestnaam = naam;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult artiestinfo()
        {

            return View();
        }
        public IActionResult Volg()
        {
            return View();
        }
        public IActionResult frequencies()
        {
            return View();
        }
        [Authorize(Roles ="Admin")]
        public IActionResult FotoToevoegen()
        {
            return View();
        }
        [HttpPost]
		[Authorize(Roles = "Admin")]
		public IActionResult FotoToevoegen(string song, string foto)
        { 
            _dbContext.Database.ExecuteSql($"spFotoToevoegen {song}, {foto}");
            return View();
        }

    }
}