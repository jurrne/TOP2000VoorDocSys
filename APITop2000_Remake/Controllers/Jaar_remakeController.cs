using Microsoft.AspNetCore.Mvc;
using APITop2000_Remake.Models_remake;
using Microsoft.EntityFrameworkCore;

namespace APITop2000_Remake.Controllers
{
		[Route("api/JaarRemakeController")]
		[ApiController]
		public class JaarRemakeController : ControllerBase
		{
			private readonly _DbContext_remake _context;

			public JaarRemakeController(_DbContext_remake context)
			{
				_context = context;
			}

			[HttpGet("{jaar}")]
			public async Task<ActionResult<IEnumerable<jaar_remake>>> GetYearlist(int jaar)
			{
				return await _context.Year.FromSql($"spLijst {jaar}").ToListAsync();
			}

		}
}