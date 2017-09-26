using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopsyTurvyCakes.Models;

namespace TopsyTurvyCakes.Pages.Admin
{
    public class AddEditRecipeModel : PageModel
    {
        private readonly IRecipesService recipesService;

        [FromRoute]
        public long? Id { get; set; }

        public bool IsNewRecipe
        {
            get { return Id == null; }
        }

        public Recipe Recipe { get; set; }

        public AddEditRecipeModel(IRecipesService recipesService)
        {
            this.recipesService = recipesService;
        }

        public async Task OnGetAsync()
        {
            Recipe = await recipesService.FindAsync(Id.GetValueOrDefault()) 
                ?? new Recipe();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            return RedirectToPage("/Recipe", new { id = Id });
        }
    }
}