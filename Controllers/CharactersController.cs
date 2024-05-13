using AvatarTLAB.Backend.Data;
using AvatarTLAB.Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AvatarTLAB.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CharactersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Character>>> GetCharacters()
        {
            var characters = await _context.Characters
                .Include(a => a.Aliases)
                .Include(e => e.Element)
                .Include(fe => fe.FirstEpisode)
                .Include(le => le.LastEpisode)
                .Include(fs => fs.CharacterFightingStyles)
                .Include(n => n.Nation)
                .ToListAsync();
            if (characters.Count <= 0)
                return NotFound("There are 0 characters registered in this service.");

            return Ok(characters);
        }

        [HttpGet("byId/{Id}")]
        public async Task<ActionResult<Character>> GetCharacterById(int Id)
        {
            var character = await _context.Characters
                .Include(a => a.Aliases)
                .Include(e => e.Element)
                .Include(fe => fe.FirstEpisode)
                .Include(le => le.LastEpisode)
                .Include(fs => fs.CharacterFightingStyles)
                .Include(n => n.Nation)
                .FirstOrDefaultAsync(c => c.Id == Id);


            if (character == null)
                return NotFound($"Character with ID {Id} not found.");

            return Ok(character);
        }

        [HttpGet("byName/{name}")]
        public async Task<ActionResult<Character>> GetCharacterByName(string name)
        {
            var character = await _context.Characters
                .Include(a => a.Aliases)
                .Include(e => e.Element)
                .Include(fe => fe.FirstEpisode)
                .Include(le => le.LastEpisode)
                .Include(fs => fs.CharacterFightingStyles)
                .Include(n => n.Nation)
                .FirstOrDefaultAsync(c => c.Name == name);
            if (character == null)
                return NotFound($"No matches for a character with name: {name}");

            return Ok(character);
        }

        [HttpGet("bySurname/{surname}")]
        public async Task<ActionResult<List<Character>>> GetCharacterBySurname(string surname)
        {
            if (string.IsNullOrEmpty(surname) || string.IsNullOrWhiteSpace(surname))
                return BadRequest("Surname cannot be null or empty.");

            var characters = await _context.Characters
                .Include(a => a.Aliases)
                .Include(e => e.Element)
                .Include(fe => fe.FirstEpisode)
                .Include(le => le.LastEpisode)
                .Include(fs => fs.CharacterFightingStyles)
                .Include(n => n.Nation)
                .Where(c => c.Surname == surname)
                .ToListAsync();
            if (characters.Count <= 0)
                return NotFound($"No matches for a character with surname: {surname}");

            return Ok(characters);
        }

        [HttpGet("byAge/{age}")]
        public async Task<ActionResult<List<Character>>> GetCharacterByAge(int age)
        {
            var characters = await _context.Characters
                .Include(a => a.Aliases)
                .Include(e => e.Element)
                .Include(fe => fe.FirstEpisode)
                .Include(le => le.LastEpisode)
                .Include(fs => fs.CharacterFightingStyles)
                .Include(n => n.Nation)
                .Where(c => c.Age == age)
                .ToListAsync();
            if (characters.Count <= 0)
                return NotFound($"No matches for a character with age: {age}");

            return Ok(characters);
        }

        [HttpGet("byElement/{element}")]
        public async Task<ActionResult<List<Character>>> GetCharacterByElement(string element)
        {
            if (string.IsNullOrEmpty(element) || string.IsNullOrWhiteSpace(element))
                return BadRequest("Element cannot be null or empty.");

            var characters = await _context.Characters
                .Include(a => a.Aliases)
                .Include(e => e.Element)
                .Include(fe => fe.FirstEpisode)
                .Include(le => le.LastEpisode)
                .Include(fs => fs.CharacterFightingStyles)
                .Include(n => n.Nation)
                .Where(c => c.Element!.Name.ToUpper() == element.ToUpper())
                .ToListAsync();
            if (characters.Count <= 0)
                return NotFound($"No matches for a character with element: {element}");

            return Ok(characters);
        }

        [HttpGet("byNation/{nation}")]
        public async Task<ActionResult<List<Character>>> GetCharacterByNation(string nation)
        {
            if (string.IsNullOrEmpty(nation) || string.IsNullOrWhiteSpace(nation))
                return BadRequest("Nation cannot be null or empty.");

            var characters = await _context.Characters
                .Include(a => a.Aliases)
                .Include(e => e.Element)
                .Include(fe => fe.FirstEpisode)
                .Include(le => le.LastEpisode)
                .Include(fs => fs.CharacterFightingStyles)
                .Include(n => n.Nation)
                .Where(c => c.Nation!.Name.ToUpper() == nation.ToUpper())
                .ToListAsync();
            if (characters.Count <= 0)
                return NotFound($"No matches for a character with nation: {nation}");

            return Ok(characters);
        }

        [HttpGet("byBorn/{born}")]
        public async Task<ActionResult<List<Character>>> GetCharacterByBorn(string born)
        {
            if (string.IsNullOrEmpty(born) || string.IsNullOrWhiteSpace(born))
                return BadRequest("Born cannot be null or empty.");

            var characters = await _context.Characters
                .Include(a => a.Aliases)
                .Include(e => e.Element)
                .Include(fe => fe.FirstEpisode)
                .Include(le => le.LastEpisode)
                .Include(fs => fs.CharacterFightingStyles)
                .Include(n => n.Nation)
                .Where(c => c.Born.ToUpper().Contains(born.ToUpper()))
                .ToListAsync();
            if (characters.Count <= 0)
                return NotFound($"No matches for a character born on: {born}");

            return Ok(characters);
        }

        [HttpGet("byHairColor/{hairColor}")]
        public async Task<ActionResult<List<Character>>> GetCharacterByHairColor(string hairColor)
        {
            if (string.IsNullOrEmpty(hairColor) || string.IsNullOrWhiteSpace(hairColor))
                return BadRequest("Hair color cannot be null or empty.");

            var characters = await _context.Characters
                .Include(a => a.Aliases)
                .Include(e => e.Element)
                .Include(fe => fe.FirstEpisode)
                .Include(le => le.LastEpisode)
                .Include(fs => fs.CharacterFightingStyles)
                .Include(n => n.Nation)
                .Where(c => c.HairColor!.ToUpper().Contains(hairColor.ToUpper().Trim()))
                .ToListAsync();
            if (characters.Count <= 0)
                return NotFound($"No matches for a character with hair color: {hairColor}");

            return Ok(characters);
        }

        [HttpGet("byEyeColor/{eyeColor}")]
        public async Task<ActionResult<List<Character>>> GetCharacterByEyeColor(string eyeColor)
        {
            if (string.IsNullOrEmpty(eyeColor) || string.IsNullOrWhiteSpace(eyeColor))
                return BadRequest("Eye color cannot be null or empty.");

            var characters = await _context.Characters
                .Include(a => a.Aliases)
                .Include(e => e.Element)
                .Include(fe => fe.FirstEpisode)
                .Include(le => le.LastEpisode)
                .Include(fs => fs.CharacterFightingStyles)
                .Include(n => n.Nation)
                .Where(c => c.EyesColor!.ToUpper().Contains(eyeColor.ToUpper().Trim()))
                .ToListAsync();
            if (characters.Count <= 0)
                return NotFound($"No matches for a character with eye color: {eyeColor}");

            return Ok(characters);
        }

        [HttpGet("bySkinColor/{skinColor}")]
        public async Task<ActionResult<List<Character>>> GetCharacterBySkinColor(string skinColor)
        {
            if (string.IsNullOrEmpty(skinColor) || string.IsNullOrWhiteSpace(skinColor))
                return BadRequest("Skin color cannot be null or empty.");

            var characters = await _context.Characters
                .Include(a => a.Aliases)
                .Include(e => e.Element)
                .Include(fe => fe.FirstEpisode)
                .Include(le => le.LastEpisode)
                .Include(fs => fs.CharacterFightingStyles)
                .Include(n => n.Nation)
                .Where(c => c.SkinColor!.ToUpper().Contains(skinColor.ToUpper().Trim()))
                .ToListAsync();
            if (characters.Count <= 0)
                return NotFound($"No matches for a character skin color: {skinColor}");

            return Ok(characters);
        }

        [HttpGet("fightingStyles/{characterId}")]
        public async Task<ActionResult<List<FightingStyle>>> GetCharacterFightingStyles(int characterId)
        {
            var character = await _context.Characters
                .Include(fs => fs.CharacterFightingStyles)
                .FirstOrDefaultAsync(c => c.Id == characterId);
            if (character == null)
                return NotFound($"Character with ID {characterId} not found.");

            return Ok(character.CharacterFightingStyles);
        }

        [HttpGet("aliases/{characterId}")]
        public async Task<ActionResult<List<Alias>>> GetCharacterAliases(int characterId)
        {
            var character = await _context.Characters
                .Include(a => a.Aliases)
                .FirstOrDefaultAsync(c => c.Id == characterId);
            if (character == null)
                return NotFound($"Character with ID {characterId} not found.");

            return Ok(character.Aliases);
        }
    }
}
