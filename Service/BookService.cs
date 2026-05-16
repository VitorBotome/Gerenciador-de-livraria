using GerenciadorDeLivraria.DTOs;
using GerenciadorDeLivraria.Models;
using GerenciadorDeLivraria.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeLivraria.Service;

public class BookService
{
    public Book CreateBook(CreateBookDto dto)
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
            Genre = dto.Genre,
            Price = dto.Price,
            Stock = dto.Stock,
            CreatedAt = DateTime.UtcNow,
        };
        BookRepository.Books.Add(book);
        return book;
    }

    public List<Book> GetAllBooks()
    {
        return BookRepository.Books;
    }

    public Book GetBookId(Guid id)
    {
        return BookRepository.Books.FirstOrDefault(b => b.Id == id);
    }

    public Book DeleteBook(Guid id)
    {
        var book = BookRepository.Books.FirstOrDefault(b => b.Id == id);

        if (book == null)
        {
            throw new Exception("Livro não encontrado");
        }
        
        BookRepository.Books.Remove(book);
        return book;
        
    }

    public Book UpdateBook(Guid id, UpdateBookDto dto)
    {
        var book = BookRepository.Books.FirstOrDefault(b => b.Id == id);
        if (book == null)
            return null;

        book.Title = dto.Title;
        book.Author = dto.Author;
        book.Genre = dto.Genre;
        book.Price = dto.Price;
        book.Stock = dto.Stock;
        book.UpdatedAt = DateTime.UtcNow;

        return book; ;
    }
}
