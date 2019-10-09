using Finance.Entity;
using Microsoft.EntityFrameworkCore;

namespace Finance.Repository.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
      
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base (options) {

        }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<User> ()
                .Property (p => p.Name)
                .HasColumnName ("Name")
                .HasMaxLength (50)
                .IsRequired ();

        }
    }
}