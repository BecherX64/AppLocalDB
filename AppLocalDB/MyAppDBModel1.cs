namespace AppLocalDB
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class MyAppDBModel1 : DbContext
	{
		public MyAppDBModel1()
			: base("name=MyAppDBModel")
		{
		}

		public virtual DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>()
				.Property(e => e.Name)
				.IsFixedLength()
				.IsUnicode(false);

			modelBuilder.Entity<Product>()
				.Property(e => e.Desc)
				.IsUnicode(false);
		}
	}
}
