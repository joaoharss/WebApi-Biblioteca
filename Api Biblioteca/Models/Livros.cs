using Api_Biblioteca.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Reflection.Metadata.Ecma335;

namespace Api_Biblioteca.Models
{
    public class Livros
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static Livros? Create(Livros livro, BibliotecaContext _bibliotecaContext)
        {

            if (String.IsNullOrEmpty(livro.Name))
            {
                return null;
            }

            _bibliotecaContext.Livros.Add(livro);
            _bibliotecaContext.SaveChanges();
            return livro;
        }

        public static string? GetNameById(int id, BibliotecaContext _bibliotecaContext)
        {
            Livros? livro = GetBookById(id, _bibliotecaContext);
            if (livro == null)
            {
                return null;
            }
            return livro.Name;
        }

        public static Livros? GetBookById(int id, BibliotecaContext _bibliotecaContext)
        {
            Livros? livroGettedById = _bibliotecaContext.Livros.Where(i => id.Equals(id)).FirstOrDefault();
            if (livroGettedById != null)
            {
                return livroGettedById;
            }
            return null;
        }
    }
}
