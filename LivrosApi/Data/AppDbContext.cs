using LivrosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LivrosApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }


        public DbSet<AuthorModel> Authors { get; set; } 
        public DbSet<BookModel> Books { get; set; } 
    }
}
