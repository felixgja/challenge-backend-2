using AutoMapper;
using challenge_backend_2.DTOs.Receita;
using challenge_backend_2.Models;

namespace challenge_backend_2.Profiles
{
    public class ReceitaProfile : Profile
    {
        public ReceitaProfile()
        {
            CreateMap<CreateReceitaDto, Receita>().ReverseMap();
            CreateMap<Receita, ReceitaDto>();
        }
        
    }
}