using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using Web.Models;

namespace Web.Pages
{
	[IgnoreAntiforgeryToken]
	public class CurrentPageModel : PageModel
	{
		public string Name { get { return Discussion.Name; } }
		public string Description { get { return Discussion.Description; } }
		public string UserName { get { return Discussion.UserName; } }

		ApplicationContext context;
		public static int Id { get; set; }

		Discussion Discussion { get; set; } = new();
		public List<Comment> Comments { get; set; } = new();

		public CurrentPageModel(ApplicationContext db)
		{
			context = db;
		}

		public void OnGet(int id)
		{
			Id = id;
			Discussion = context.Discussions.Where(d => d!.Id == Id).ToList()[0];
			Comments = context.Comments.Where(c => c.DiscussionID == Id).ToList();
		}

		public async Task<IActionResult> OnPostAsync(string username, string comment)
		{
			context.Comments.Add(new Comment { UserName = username, CommentText = comment, DiscussionID = Id });
			await context.SaveChangesAsync();
			return Redirect($"CurrentPage?id={Id}");
		}

	}
}
