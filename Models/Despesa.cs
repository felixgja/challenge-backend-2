using challenge_backend_2.Models.Enums;

namespace challenge_backend_2.Models
{
    public class Despesa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public CategoriaType Categoria { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
    }
}