namespace ControleFinanceiro.Domain.Models;

public class Receita
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public double Valor { get; set; }
    public DateTime Data { get; set; }
}