using challenge_backend_2.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace challenge_backend_2.DTOs.Resumo
{
    public class ResumoDto
    {
        [Precision(14,2)]
        public double ValorTotalReceitas { get; set; }
        [Precision(14,2)]
        public double ValorTotalDespesas { get; set; }
        [Precision(14,2)]
        public double Saldo { get; set; }
        public IEnumerable<GastoCategoriaDto> GastoCategoria { get; set; }
    }

    public class GastoCategoriaDto
    {
        public CategoriaType Categoria { get; set; }
        [Precision(14,2)]
        public double Valor { get; set; }
    }
}