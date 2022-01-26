using System.ComponentModel.DataAnnotations;

namespace challenge_backend_2.DTOs.Despesa
{
    public class CreateDespesaDto
    {
        [Required]
        public string Descricao { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public DateTime Data { get; set;}        
    }
}