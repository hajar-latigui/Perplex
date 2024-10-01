using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Perplex.Data;
using Perplex.Models;

namespace Perplex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuggestionController : ControllerBase
    {
        private readonly SuggestionDbContext _context;

        public SuggestionController(SuggestionDbContext context)
        {
            _context = context;
        }

        // POST: api/Suggestions

        [HttpPost]
        public async Task<ActionResult<Suggestion>> PostSuggestion([FromBody] Suggestion suggestion)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Onjuist verzoek: Controleer de ingevoerde gegevens." });
            }
            if (ModelState.IsValid)
            {
                _context.Add(suggestion);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    var validationErrors = ex.Entries.Select(e => e.Entity);
                }
            }

            return Ok(new { message = "Suggestie succesvol opgeslagen!" });
        }
    }
        
}
