using System.ComponentModel.DataAnnotations;

namespace challenge_backend_2.DTOs.Despesa
{
    public abstract class DespesaDto
    {
        [Required]
        public string Descricao { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public DateTime Data { get; set;}
    }
}