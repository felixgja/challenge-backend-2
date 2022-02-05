using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Dtos.Receita;

namespace ControleFinanceiro.Application.Interfaces;

public interface IReceitaService
{
    Task<bool> Verifica(CreateReceitaDto receitaDto);
    Task<RespostaDto<CreateReceitaDto>> CreateReceitaAsync(CreateReceitaDto receitaDto);
    Task<RespostaDto<RetornoReceitaDto>> GetReceitaByIdAsync(int id);
    Task<RespostaDto<IEnumerable<RetornoReceitaDto>>> GetReceitasAsync(string? descricao);
    Task<RespostaDto<IEnumerable<RetornoReceitaDto>>> GetReceitasByDateAsync(int ano, int mes);
    Task<RespostaDto<CreateReceitaDto>> UpdateReceitaAsync(int id, CreateReceitaDto receitaDto);
    Task<RespostaDto> DeleteReceitaAsync(int id);
}