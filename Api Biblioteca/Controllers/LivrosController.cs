using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api_Biblioteca.Models;
using Api_Biblioteca.Context;

namespace Api_Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        //Contexto (No momento ele está na memória do computador, pode-se verificar em Program.cs na linha 15, 16);
        private readonly BibliotecaContext _bibliotecaContext;
        public LivrosController(BibliotecaContext _context)
        {
            _bibliotecaContext = _context;
        }

        [HttpGet("{id}")] //O parâmetro passado dentro das chaves `{}` representa o parâmetro pedido ao fazer a request.
        public ActionResult GetLivroById(int id)
        {
            Livros? livro = Livros.GetBookById(id, _bibliotecaContext);

            if (livro == null)
            {
                return NotFound("Livro não encontrado.");
            }
            return Ok(livro);

        }

        [HttpPost]
        public ActionResult CreateLivro([FromBody]Livros livro) //Utiliza-se o FromBody quando você espera receber um JSON ou quando o parâmetro não é um tipo primitivo. 
        {
            if(Livros.Create(livro, _bibliotecaContext) == null)
                return BadRequest("Não é possível criar um livro sem informações.");
            return Ok(livro);
        }
    }
}
