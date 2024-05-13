using AvatarTLAB.Backend.Data;
using AvatarTLAB.Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AvatarTLAB.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EpisodesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Episode>>> GetEpisodes()
        {
            var episodes = await _context.Episodes.ToListAsync();
            if (episodes.Count <= 0)
                return NotFound("There are 0 episodes registered in this service.");

            return Ok(episodes);
        }
    }
}
