using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFinanceiro.Application.Dtos.Resumo;
using ControleFinanceiro.Application.Interfaces;

namespace ControleFinanceiro.Application.Services;

public class ResumoService : IResumoService
{
    public Task<ResumoDto> GetResumoAsync(int ano, int mes)
    {
        throw new NotImplementedException();
    }
}