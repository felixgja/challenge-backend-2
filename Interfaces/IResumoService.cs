using challenge_backend_2.DTOs.Resumo;

namespace challenge_backend_2.Interfaces

{
    public interface IResumoService
    {
        Task<ResumoDto> GetResumoAsync(int ano, int mes);
    }
}