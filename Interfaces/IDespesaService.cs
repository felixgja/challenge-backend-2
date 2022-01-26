using challenge_backend_2.DTOs.Despesa;

namespace challenge_backend_2.Interfaces
{
public interface IDespesaService
    {
        Task<CreateDespesaDto?> CreateDespesaAsync(CreateDespesaDto despesaDto);
        Task<bool> DeleteDespesaAsync(int id);
        Task<DespesaDto> GetDespesaByIdAsync(int id);
        Task<IEnumerable<DespesaDto>> GetDespesasAsync();
        Task<CreateDespesaDto?> UpdateDespesaAsync(int id, CreateDespesaDto despesaDto);
        Task<bool> Verifica(CreateDespesaDto despesaDto);
    }
}