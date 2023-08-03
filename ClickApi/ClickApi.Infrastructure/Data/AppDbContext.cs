

using ClickApi.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ClickApi.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
       public DbSet<ShortenedLink> ShortenedLinks {  get; set; }


    }
}
