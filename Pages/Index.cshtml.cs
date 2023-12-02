using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        ApplicationContext context;       
        public List<Discussion> Discussions { get; set; } = new();
		public IndexModel(ApplicationContext db)
		{
			context = db;			
		}

		public void OnGet()
        {           
           Discussions = context.Discussions.AsNoTracking().ToList();       
        }

		public async Task<IActionResult> OnPostAsync(string username, string discussionsname, string description)
		{
			context.Discussions.Add(new Discussion { UserName = username, Name = discussionsname, Description = description });
			await context.SaveChangesAsync();
			return RedirectToPage();
		}
    }
}
