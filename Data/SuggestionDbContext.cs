using Microsoft.EntityFrameworkCore;
using Perplex.Models;


namespace Perplex.Data
{
    public class SuggestionDbContext: DbContext
    {
        public SuggestionDbContext(DbContextOptions<SuggestionDbContext> options)
        : base(options)
        {
        }

        public DbSet<Suggestion> Suggestions { get; set; }
    }

}

