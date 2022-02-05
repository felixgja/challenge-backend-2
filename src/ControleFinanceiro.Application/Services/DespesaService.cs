using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Dtos.Despesa;
using ControleFinanceiro.Application.Interfaces;

namespace ControleFinanceiro.Application.Services;

public class DespesaService : IDespesaService
{
    public Task<RespostaDto<CreateDespesaDto>> CreateDespesaAsync(CreateDespesaDto despesaDto)
    {
        throw new NotImplementedException();
    }

    public Task<RespostaDto> DeleteDespesaAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<RespostaDto<RetornoDespesaDto>> GetDespesaByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<RespostaDto<IEnumerable<RetornoDespesaDto>>> GetDespesasAsync(string? descricao)
    {
        throw new NotImplementedException();
    }

    public Task<RespostaDto<IEnumerable<RetornoDespesaDto>>> GetDespesasByDateAsync(int ano, int mes)
    {
        throw new NotImplementedException();
    }

    public Task<RespostaDto<CreateDespesaDto>> UpdateDespesaAsync(int id, CreateDespesaDto despesaDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Verifica(CreateDespesaDto despesaDto)
    {
        throw new NotImplementedException();
    }
}