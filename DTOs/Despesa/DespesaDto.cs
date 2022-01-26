using System.ComponentModel.DataAnnotations;

namespace challenge_backend_2.DTOs.Despesa
{
    public class DespesaDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public DateTime Data { get; set;}     
    }
}