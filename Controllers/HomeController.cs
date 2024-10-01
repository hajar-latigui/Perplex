using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Perplex.Data;
using Perplex.Models;

namespace Perplex.Controllers
{
    public class HomeController : Controller
    {
        private readonly SuggestionDbContext _context;

        public HomeController(SuggestionDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string type)
        {
            var suggestions = await _context.Suggestions.ToListAsync();

            if (!string.IsNullOrEmpty(type))
            {
                suggestions = await _context.Suggestions.Where(s => s.Type.ToLower() == type.ToLower()).ToListAsync();
            }

            // Pass the current filter to the view for form persistence
            ViewBag.CurrentFilter = type;

            var sortedSuggestions = suggestions.OrderByDescending(s => s.CreatedDate).ToList();
            // Pass the filtered suggestions to the view
            return View(sortedSuggestions);
        }

    }
}
