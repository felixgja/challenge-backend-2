using challenge_backend_2.DTOs;
using challenge_backend_2.DTOs.Despesa;

namespace challenge_backend_2.Interfaces
{
public interface IDespesaService
    {
        Task<RespostaDto<CreateDespesaDto>> CreateDespesaAsync(CreateDespesaDto despesaDto);
        Task<RespostaDto<IEnumerable<DespesaDto>>> GetDespesasAsync(string? descricao);
        Task<RespostaDto<IEnumerable<DespesaDto>>> GetDespesasByDateAsync(int ano, int mes);
        Task<RespostaDto<DespesaDto>> GetDespesaByIdAsync(int id);
        Task<RespostaDto<CreateDespesaDto>> UpdateDespesaAsync(int id, CreateDespesaDto despesaDto);
        Task<RespostaDto> DeleteDespesaAsync(int id);
        Task<bool> Verifica(CreateDespesaDto despesaDto);
    }
}