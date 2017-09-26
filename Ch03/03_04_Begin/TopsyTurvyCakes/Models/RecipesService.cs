using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace TopsyTurvyCakes.Models
{
    public class RecipesService : IRecipesService
    {
        private readonly RecipesDbContext _context;

        public RecipesService()
        {
            var options = new DbContextOptionsBuilder<RecipesDbContext>()
                .UseInMemoryDatabase("TopsyTurvyCakes")
                .Options;

            _context = new RecipesDbContext(options);
        }

        public RecipesService(RecipesDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(long id)
        {
            _context.Recipes.Remove(new Recipe { Id = id });
            await _context.SaveChangesAsync();
        }

        public Recipe Find(long id)
        {
            return _context.Recipes.FirstOrDefault(x => x.Id == id);
        }

        public Task<Recipe> FindAsync(long id)
        {
            return _context.Recipes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Recipe> GetAll(int? count = null, int? page = null)
        {
            var actualCount = count.GetValueOrDefault(10);

            return _context.Recipes
                    .Skip(actualCount * page.GetValueOrDefault(0))
                    .Take(actualCount);
        }

        public Task<Recipe[]> GetAllAsync(int? count = null, int? page = null)
        {
            return GetAll(count, page).ToArrayAsync();
        }

        public async Task SaveAsync(Recipe recipe)
        {
            var isNew = recipe.Id == default(long);

            _context.Entry(recipe).State = isNew ? EntityState.Added : EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
