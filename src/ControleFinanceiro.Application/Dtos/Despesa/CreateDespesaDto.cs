using System.ComponentModel.DataAnnotations;
using ControleFinanceiro.Domain.Models.Enums;

namespace ControleFinanceiro.Application.Dtos.Despesa;

public class CreateDespesaDto
{
    [Required(ErrorMessage = "Necessário definir uma descrição de no máximo 50 caractéres")]
    [StringLength(maximumLength:50,MinimumLength = 1, 
        ErrorMessage = "Descrição deve ter um máximo de {1} e mínimo de {2} caretéres")]
    public string Descricao { get; set; }

    public CategoriaType? Categoria { get; set; } = CategoriaType.Outras;
    [Required(ErrorMessage = "Valor obrigatório!")]
    public double Valor { get; set; }
    [Required(ErrorMessage = "Valor obrigatório!")]
    public DateTime Data { get; set;}        
}