using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace challenge_backend_2.Models
{
    
    [Table("Despesas")]
    public class Despesa
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public DateTime Data { get; set; }

        public Despesa(int id, string descricao, double valor, DateTime data)
        {
            Id = id;
            Descricao = descricao;
            Valor = valor;
            Data = data;
        }
    }
}