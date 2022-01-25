using AutoMapper;
using challenge_backend_2.DTOs.Despesa;
using challenge_backend_2.Models;

namespace challenge_backend_2.Profiles
{
    public class DespesaProfile : Profile
    {
        public DespesaProfile()
        {
            CreateMap<CreateDespesaDto, Despesa>();
            CreateMap<Despesa, ReadDespesaDto>();
            CreateMap<UpdateDespesaDto, Despesa>();
        }
        
    }
}