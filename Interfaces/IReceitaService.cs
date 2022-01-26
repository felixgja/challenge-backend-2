using challenge_backend_2.DTOs.Receita;

namespace challenge_backend_2.Interfaces
{
public interface IReceitaService
    {
        Task<CreateReceitaDto?> CreateReceitaAsync(CreateReceitaDto ReceitaDto);
        Task<bool> DeleteReceitaAsync(int id);
        Task<ReceitaDto> GetReceitaByIdAsync(int id);
        Task<IEnumerable<ReceitaDto>> GetReceitasAsync();
        Task<CreateReceitaDto?> UpdateReceitaAsync(int id, CreateReceitaDto ReceitaDto);
        Task<bool> Verifica(CreateReceitaDto ReceitaDto);
    }
}