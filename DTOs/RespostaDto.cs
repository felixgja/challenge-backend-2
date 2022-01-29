namespace challenge_backend_2.DTOs
{
    public class RespostaDto<T> where T : class
    {
        public bool Sucess {get; set;} = true;
        public T? Conteudo { get; set; }
        public List<string> Alertas { get; set; } = new();
    }

    public class RespostaDto
    {
        public bool Sucess {get; set;} = true;
        public List<string> Alertas { get; set; } = new();
    }
}