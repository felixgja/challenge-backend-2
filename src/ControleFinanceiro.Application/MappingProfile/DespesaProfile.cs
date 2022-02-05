using AutoMapper;
using ControleFinanceiro.Application.Dtos.Despesa;
using ControleFinanceiro.Domain.Models;

namespace ControleFinanceiro.Application.MappingProfile;

public class DespesaProfile : Profile
{
    public DespesaProfile()
    {
        CreateMap<CreateDespesaDto, Despesa>().ReverseMap();
        CreateMap<Despesa, RetornoDespesaDto>();
    }        
}