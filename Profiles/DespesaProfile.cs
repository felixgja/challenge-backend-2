using AutoMapper;
using challenge_backend_2.DTOs.Despesa;
using challenge_backend_2.Models;

namespace challenge_backend_2.Profiles
{
    public class DespesaProfile : Profile
    {
        public DespesaProfile()
        {
            CreateMap<CreateDespesaDto, Despesa>().ReverseMap();
            CreateMap<Despesa, DespesaDto>();
        }
        
    }
}