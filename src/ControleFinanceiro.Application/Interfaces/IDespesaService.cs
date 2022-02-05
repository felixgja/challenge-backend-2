using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Dtos.Despesa;

namespace ControleFinanceiro.Application.Interfaces;

public interface IDespesaService
{
    Task<bool> Verifica(CreateDespesaDto despesaDto);
    Task<RespostaDto<CreateDespesaDto>> CreateDespesaAsync(CreateDespesaDto despesaDto);
    Task<RespostaDto<RetornoDespesaDto>> GetDespesaByIdAsync(int id);
    Task<RespostaDto<IEnumerable<RetornoDespesaDto>>> GetDespesasAsync(string? descricao);
    Task<RespostaDto<IEnumerable<RetornoDespesaDto>>> GetDespesasByDateAsync(int ano, int mes);
    Task<RespostaDto<CreateDespesaDto>> UpdateDespesaAsync(int id, CreateDespesaDto despesaDto);
    Task<RespostaDto> DeleteDespesaAsync(int id);
}