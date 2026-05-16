using GerenciadorDeLivraria.Models;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeLivraria.DTOs;

public class CreateBookDto
{
    [Required(ErrorMessage = "O titulo é obrigatório")]
    [StringLength(120, MinimumLength = 2, ErrorMessage = "O titulo deve ter entre 2 e 120 caracteres.")]
    public string Title { get; set; } = string.Empty;

    
    [StringLength(120, MinimumLength = 2, ErrorMessage = "O nome do autor deve ter entre 2 e 120 caracteres.")]
    public string? Author { get; set; }

    [Required(ErrorMessage = "O genero é Obrigatorio")]
    [EnumDataType(typeof(GeneroLivroEnum), ErrorMessage = "Genero invalido. Escolha entre: Ficcao, Romance, Misterio, Terror ou outros.")]
    public GeneroLivroEnum Genre { get; set; }

    [Required(ErrorMessage = "O valor é obrigatorio")]
    [Range(typeof(decimal),"0", "79228162514264337593543950335", ErrorMessage = "O preço deve ser maior ou igual a 0")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "É preciso informar a quantidade no estoque")]
    [Range(0, int.MaxValue, ErrorMessage = "A quantidade minima e 0")]
    public int Stock { get; set; }

}
