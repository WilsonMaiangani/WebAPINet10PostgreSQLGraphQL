// DTOs/CategoriaInputs.cs
using System.ComponentModel.DataAnnotations;

namespace WebAPI_Net10_PostgreSQL_GraphQL.DTOs;

public record CriarCategoriaInput(
    [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres.")]
    string Nome
);

public record AtualizarCategoriaInput(
    int Id,
    [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres.")]
    string Nome
);
