using AvatarTLAB.Backend.Data;
using AvatarTLAB.Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AvatarTLAB.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AliasesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AliasesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Alias>>> GetAliases()
        {
            var aliases = await _context.Aliases.ToListAsync();
            if (aliases.Count <= 0)
                return NotFound("There are 0 aliases registered in this service.");

            return Ok(aliases);
        }
    }
}
