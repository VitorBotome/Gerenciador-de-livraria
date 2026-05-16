using GerenciadorDeLivraria.DTOs;
using GerenciadorDeLivraria.Service;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeLivraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _service = new BookService();


        [HttpPost]
        public IActionResult CreateNewBook([FromBody] CreateBookDto dto)
        {
            _service.CreateBook(dto);

            return Ok("Livro criado com sucesso!");
        }


        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _service.GetAllBooks();
          
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(Guid id)
        {
            var book = _service.GetBookId(id);

            if (book == null)
            {
                return NotFound("Livro nao encontrado");
            }
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(Guid id)
        {
            _service.DeleteBook(id);
            return Ok("Livro deletado");
        }
    }
}
