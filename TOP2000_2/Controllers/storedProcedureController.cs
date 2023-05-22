using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Top2000_2.Controllers;
using Top2000_2.Data;

namespace TOP2000_2.Controllers
{
    public class storedProcedureController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<HomeController> _logger;

        public storedProcedureController(ILogger<HomeController> logger, ApplicationDbContext dbcontext)
        {
            _dbContext = dbcontext;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult storedProcedure1(int jaar = 2021)
        {
            var lijst = _dbContext.VmDaling.FromSqlInterpolated($"spDalingTOVvorigjaar {jaar}").ToList();
            ViewBag.filteredData = lijst;
            return View();
        }
		public IActionResult storedProcedure2(int jaar = 2021)
		{
			var lijst = _dbContext.vmStijging.FromSqlInterpolated($"spStijgingVanSongs {jaar}").ToList();
			ViewBag.filteredData = lijst;
			return View();
		}
		public IActionResult storedProcedure3()
		{
			var lijst = _dbContext.vmAlleEdities.FromSqlInterpolated($"spAlleEdities").ToList();
			ViewBag.filteredData = lijst;
			return View();
		}
		public IActionResult storedProcedure4(int jaar = 2021)
		{
			var lijst = _dbContext.vmNieuwInLijst.FromSqlInterpolated($"spNieuwInLijst {jaar}").ToList();
			ViewBag.filteredData = lijst;
			return View();
		}
		public IActionResult storedProcedure5(int jaar = 2021)
		{
			var lijst = _dbContext.vmVerwijderdVanLijst.FromSqlInterpolated($"spVerwijderdVanLijst {jaar}").ToList();
			ViewBag.filteredData = lijst;
			return View();
		}
		public IActionResult storedProcedure6(int jaar = 2021)
		{
			var lijst = _dbContext.vmNieuwInLijst.FromSqlInterpolated($"spNieuwInLijst {jaar}").ToList();
			ViewBag.filteredData = lijst;
			return View();
		}
		public IActionResult storedProcedure7(int jaar = 2021)
		{
			var lijst = _dbContext.VmZelfdePositie.FromSqlInterpolated($"spZelfdePositie {jaar}").ToList();
			ViewBag.filteredData = lijst;
			return View();
		}
		public IActionResult storedProcedure8(int jaar = 2021)
		{
			var lijst = _dbContext.vmsp8.FromSqlInterpolated($"sp8 {jaar}").ToList();
			ViewBag.filteredData = lijst;
			return View();
		}
		public IActionResult storedProcedure9()
		{
			var lijst = _dbContext.vmEenKeerInTop2000.FromSqlInterpolated($"spEenKeerInTop2000").ToList();
			ViewBag.filteredData = lijst;
			return View();
		}
		public IActionResult storedProcedure10(int jaar = 2021)
		{
			var lijst = _dbContext.vm3ArtiestenMetMeesteNummer.FromSqlInterpolated($"sp3ArtiestenMetMeesteNummer {jaar}").ToList();
			ViewBag.filteredData = lijst;
			return View();
		}
	}
}
