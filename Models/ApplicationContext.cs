using Microsoft.EntityFrameworkCore;

namespace Web.Models
{
	public class ApplicationContext : DbContext
	{
		public DbSet<Discussion> Discussions { get; set; } = null!;
		public DbSet<Comment> Comments { get; set; } = null!;
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=webdb;Trusted_Connection=True;");
		}
		public ApplicationContext(DbContextOptions<ApplicationContext> options)
		   : base(options)
		{
			Database.EnsureCreated();  
		}
	}
}
