using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace challenge_backend_2.Models
{
    [Table("Receitas")]
    public class Receita
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public DateTime Data { get; set; }

        public Receita(int id, string descricao, double valor, DateTime data)
        {
            Id = id;
            Descricao = descricao;
            Valor = valor;
            Data = data;
        }
    }
}