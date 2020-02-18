using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
		}

        public DbSet<FileData> FileData { get; set; }
    }
}
