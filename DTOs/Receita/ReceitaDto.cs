using System.ComponentModel.DataAnnotations;

namespace challenge_backend_2.DTOs.Receita
{
    public abstract class ReceitaDto
    {
        [Required]
        public string Descricao { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public DateTime Data { get; set;}
    }
}