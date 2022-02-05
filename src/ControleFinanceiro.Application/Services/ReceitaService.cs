using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Dtos.Receita;
using ControleFinanceiro.Application.Interfaces;

namespace ControleFinanceiro.Application.Services;

public class ReceitaService : IReceitaService
{
    public Task<RespostaDto<CreateReceitaDto>> CreateReceitaAsync(CreateReceitaDto receitaDto)
    {
        throw new NotImplementedException();
    }

    public Task<RespostaDto> DeleteReceitaAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<RespostaDto<RetornoReceitaDto>> GetReceitaByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<RespostaDto<IEnumerable<RetornoReceitaDto>>> GetReceitasAsync(string? descricao)
    {
        throw new NotImplementedException();
    }

    public Task<RespostaDto<IEnumerable<RetornoReceitaDto>>> GetReceitasByDateAsync(int ano, int mes)
    {
        throw new NotImplementedException();
    }

    public Task<RespostaDto<CreateReceitaDto>> UpdateReceitaAsync(int id, CreateReceitaDto receitaDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Verifica(CreateReceitaDto receitaDto)
    {
        throw new NotImplementedException();
    }
}