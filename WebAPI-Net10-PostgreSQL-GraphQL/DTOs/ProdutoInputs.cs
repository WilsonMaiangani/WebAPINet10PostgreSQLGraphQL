// DTOs/ProdutoInputs.cs
using System.ComponentModel.DataAnnotations;

namespace WebAPI_Net10_PostgreSQL_GraphQL.DTOs;

public record CriarProdutoInput(
    [Required(ErrorMessage = "O nome do produto é obrigatório.")]
    [StringLength(150, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 150 caracteres.")]
    string Nome,

    [Range(0.01, 999999.99, ErrorMessage = "O preço deve ser maior que zero.")]
    decimal Preco,

    [Required]
    int CategoriaId
);

public record AtualizarProdutoInput(
    int Id,
    [Required(ErrorMessage = "O nome do produto é obrigatório.")]
    [StringLength(150, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 150 caracteres.")]
    string Nome,

    [Range(0.01, 999999.99, ErrorMessage = "O preço deve ser maior que zero.")]
    decimal Preco,

    [Required]
    int CategoriaId
);
