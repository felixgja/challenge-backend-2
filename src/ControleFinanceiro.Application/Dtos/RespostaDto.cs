namespace ControleFinanceiro.Application.Dtos;

public class RespostaDto<T> where T : class
{
    public bool Sucesso {get; set;} = true;
    public T? Conteudo { get; set; }
    public List<string> Alertas { get; set; } = new();
}

public class RespostaDto
{
    public bool Sucesso {get; set;} = true;
    public List<string> Alertas { get; set; } = new();
}