using AutoMapper;
using ControleFinanceiro.Application.Dtos.Receita;
using ControleFinanceiro.Domain.Models;

namespace ControleFinanceiro.Application.MappingProfile;

public class ReceitaProfile : Profile
{
    public ReceitaProfile()
    {
        CreateMap<CreateReceitaDto, Receita>().ReverseMap();
        CreateMap<Receita, RetornoReceitaDto>();
    }        
}
