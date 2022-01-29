namespace challenge_backend_2.DTOs.Receita
{
    public class ReceitaDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
    }
}