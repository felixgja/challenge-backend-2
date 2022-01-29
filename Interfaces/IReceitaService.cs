using challenge_backend_2.DTOs;
using challenge_backend_2.DTOs.Receita;

namespace challenge_backend_2.Interfaces
{
public interface IReceitaService
    {
        Task<bool> Verifica(CreateReceitaDto ReceitaDto);
        Task<RespostaDto<CreateReceitaDto>> CreateReceitaAsync(CreateReceitaDto ReceitaDto);
        Task<RespostaDto<ReceitaDto>> GetReceitaByIdAsync(int id);
        Task<RespostaDto<IEnumerable<ReceitaDto>>> GetReceitasAsync(string? descricao);
        Task<RespostaDto<IEnumerable<ReceitaDto>>> GetReceitasByDateAsync(int ano, int mes);
        Task<RespostaDto<CreateReceitaDto>> UpdateReceitaAsync(int id, CreateReceitaDto ReceitaDto);
        Task<RespostaDto> DeleteReceitaAsync(int id);
    }
}