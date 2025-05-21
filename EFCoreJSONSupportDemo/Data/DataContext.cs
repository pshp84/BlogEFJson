using EFCoreJSONSupportDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreJSONSupportDemo.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Your_Connection_String");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().OwnsMany(u => u.Hobbies).ToJson();
        }

        public DbSet<User> Users { get; set; }
    }
}
