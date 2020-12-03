using gustav_v2.entity;
using Microsoft.EntityFrameworkCore;

namespace gustav_v2.db_context
{
    public class AdvertContext : DbContext
    {
        public DbSet<Advert> Advert { get; set; }
        
        public AdvertContext()
        {
        //    Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=advertdb2;Trusted_Connection=True;");
        }
    }
}