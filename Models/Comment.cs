namespace Web.Models
{
	public class Comment
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public int DiscussionID { get; set; }
		public string CommentText { get; set; }
	}
}
