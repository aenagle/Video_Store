using Microsoft.EntityFrameworkCore;

namespace Video_Store
{
    public class VideoStoreContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public VideoStoreContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=VideoStoreDb;Username=postgres;Password=KekaNestea");
        }
    }
}