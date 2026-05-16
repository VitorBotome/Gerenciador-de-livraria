using GerenciadorDeLivraria.DTOs;
using GerenciadorDeLivraria.Models;
using GerenciadorDeLivraria.Repositories;

namespace GerenciadorDeLivraria.Service;

public class BookService
{
    public void CreateBook(CreateBookDto dto)
    {
        if (dto.Title == dto.Author)
        {
            throw new Exception("Titulo nao pode ser igual ao autor");
        }

        var book = new Book
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Author  = dto.Author,
        };
        BookRepository.Books.Add(book);
    }

    public List<Book> GetAllBooks()
    {
        return BookRepository.Books;
    }

    public Book GetBookId(Guid id)
    {
        return BookRepository.Books.FirstOrDefault(b => b.Id == id);
    }

    public void DeleteBook(Guid id)
    {
        var book = BookRepository.Books.FirstOrDefault(b => b.Id == id);

        if (book == null)
        {
            throw new Exception("Livro não encontrado");
        }
        
        BookRepository.Books.Remove(book);
        
    }
}
