using AvatarTLAB.Backend.Data;
using AvatarTLAB.Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AvatarTLAB.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public NationsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Nation>>> GetNations()
        {
            var nations = await _context.Nations.ToListAsync();
            if (nations.Count <= 0)
                return NotFound("There are 0 nations registered in this service.");

            return Ok(nations);
        }

    }
}
