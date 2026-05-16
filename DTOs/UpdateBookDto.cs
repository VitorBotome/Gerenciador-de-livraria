using GerenciadorDeLivraria.Models;

namespace GerenciadorDeLivraria.DTOs;

public class UpdateBookDto
{
    public string Title { get; set; }
    public string Author { get; set; }

    public GeneroLivroEnum Genre { get; set; }
    public decimal Price { get; set; }
    public DateTime Updateat { get; set; }
    public int Stock {  get; set; }
}
