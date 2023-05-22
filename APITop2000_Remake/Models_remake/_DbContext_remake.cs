using Microsoft.EntityFrameworkCore;

namespace APITop2000_Remake.Models_remake
{
	public class _DbContext_remake : DbContext
	{
		public _DbContext_remake(DbContextOptions options) : base(options)
		{
		}

		public DbSet<jaar_remake> Year { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<jaar_remake>().ToView("spLijst").HasNoKey();
		}
	}
}