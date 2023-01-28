using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;

namespace WebApiAutoresDb
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Autor> Autores { get; set; }
    }
}
