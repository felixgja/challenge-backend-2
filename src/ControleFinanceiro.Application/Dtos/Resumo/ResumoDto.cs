using ControleFinanceiro.Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Application.Dtos.Resumo;

public class ResumoDto
{
    [Precision(14,2)]
    public double ValorTotalReceitas { get; set; }
    [Precision(14,2)]
    public double ValorTotalDespesas { get; set; }
    [Precision(14,2)]
    public double Saldo { get; set; }
    public IEnumerable<GastoCategoriaDto> GastoCategoria { get; set; }
}

public class GastoCategoriaDto
{
    public CategoriaType Categoria { get; set; }
    [Precision(14,2)]
    public double Valor { get; set; }
}
