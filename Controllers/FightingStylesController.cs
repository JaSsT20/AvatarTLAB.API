using AvatarTLAB.Backend.Data;
using AvatarTLAB.Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AvatarTLAB.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FightingStylesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public FightingStylesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<FightingStyle>>> GetFightingStyles()
        {
            var fightingStyles = await _context.FightingStyles.Include(e => e.Element).ToListAsync();
            if (fightingStyles.Count <= 0)
                return NotFound("There are 0 fighting styles registered in this service.");

            return Ok(fightingStyles);
        }
    }
}
