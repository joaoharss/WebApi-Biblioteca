using Api_Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Biblioteca.Context
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options) { }

        public DbSet<Livros> Livros { get; set; } = null!;
    }
}
