using ControleFinanceiro.Application.Dtos.Resumo;

namespace ControleFinanceiro.Application.Interfaces;

public interface IResumoService
{
    Task<ResumoDto> GetResumoAsync(int ano, int mes);
}