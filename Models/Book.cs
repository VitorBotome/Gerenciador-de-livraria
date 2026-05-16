namespace GerenciadorDeLivraria.Models;

public class Book : BaseEntity
{
    
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = "Desconhecido";
    public GeneroLivroEnum Genre { get; set;}
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
