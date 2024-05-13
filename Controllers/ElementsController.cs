using AvatarTLAB.Backend.Data;
using AvatarTLAB.Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AvatarTLAB.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElementsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ElementsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Element>> GetElements()
        {
            var elements = await _context.Elements.ToListAsync();
            if (elements.Count <= 0)
                return NotFound("There are 0 elements registered in this service.");

            return Ok(elements);
        }
    }
}
