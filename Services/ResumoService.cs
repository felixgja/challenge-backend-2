using challenge_backend_2.Data;
using challenge_backend_2.DTOs.Resumo;
using challenge_backend_2.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace challenge_backend_2.Services
{
    public class ResumoService : IResumoService
    {
        private readonly DataContext _context;

        public ResumoService(DataContext context)
        {
            _context = context;
        }

        public async Task<ResumoDto> GetResumoAsync(int ano, int mes)
        {
            var receitas = await _context.Receitas.Where(x => x.Data.Year.Equals(ano) && x.Data.Month.Equals(mes)).ToListAsync();
            var despesas = await _context.Despesas.Where(x => x.Data.Year.Equals(ano) && x.Data.Month.Equals(mes)).ToListAsync();
            
            var totalReceitas = receitas.Sum(x => x.Valor);
            var totalDespesas = despesas.Sum(x => x.Valor);
            var gastoCategorias = despesas.GroupBy(x => x.Categoria).Select(x => new GastoCategoriaDto{Categoria = x.Key, Valor = x.Sum(y => y.Valor)} );

            ResumoDto resumo = new ResumoDto
                {
                    ValorTotalReceitas = totalReceitas,
                    ValorTotalDespesas = totalDespesas,
                    Saldo = totalReceitas - totalDespesas,
                    GastoCategoria = gastoCategorias
                };

            return resumo;
        }
    }
}