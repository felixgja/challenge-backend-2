using ControleFinanceiro.Domain.Models.Enums;

namespace ControleFinanceiro.Domain.Models;
public class Despesa
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public CategoriaType Categoria { get; set; }
    public double Valor { get; set; }
    public DateTime Data { get; set; }
}
