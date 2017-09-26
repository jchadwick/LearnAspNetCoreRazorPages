using System.Linq;
using System.Threading.Tasks;

namespace TopsyTurvyCakes.Models
{
    public interface IRecipesService
    {
        Task DeleteAsync(long id);
        Recipe Find(long id);
        Task<Recipe> FindAsync(long id);
        IQueryable<Recipe> GetAll(int? count = null, int? page = null);
        Task<Recipe[]> GetAllAsync(int? count = null, int? page = null);
        Task SaveAsync(Recipe recipe);
    }
}
