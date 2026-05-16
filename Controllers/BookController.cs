using GerenciadorDeLivraria.DTOs;
using GerenciadorDeLivraria.Models;
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
        [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateNewBook([FromBody] CreateBookDto dto)
        {
            var book = _service.CreateBook(dto);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book); // 201
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
        public IActionResult GetBooks()
        {
            var books = _service.GetAllBooks();
          
            return Ok(books);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteBook(Guid id)
        {
            var deleted = _service.DeleteBook(id);
            return Ok("Livro deletado");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PutBook(Guid id, [FromBody] UpdateBookDto dto)
        {
            var book = _service.UpdateBook(id, dto); 
            if (book == null)
                return NotFound("Livro nao encontrado");

            return Ok(book);

        }
    }
}
