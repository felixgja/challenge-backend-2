using AutoMapper;
using challenge_backend_2.Data;
using challenge_backend_2.DTOs.Receita;
using challenge_backend_2.Interfaces;
using challenge_backend_2.Models;
using Microsoft.EntityFrameworkCore;

namespace challenge_backend_2.Services
{
    public class ReceitaService : IReceitaService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ReceitaService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Verifica(CreateReceitaDto receitaDto)
        {
            if (await _context.Receitas.AnyAsync(x => x.Descricao == receitaDto.Descricao
                && x.Data.Year == receitaDto.Data.Year
                && x.Data.Month == receitaDto.Data.Month))
            {
                return true;
            }
            else
                return false;

        }

        public async Task<CreateReceitaDto?> CreateReceitaAsync(CreateReceitaDto receitaDto)
        {
            if (await Verifica(receitaDto))
            {
                return null;
            }
            _context.Receitas.Add(_mapper.Map<Receita>(receitaDto));
            await _context.SaveChangesAsync();
            return receitaDto;
        }

        public async Task<IEnumerable<ReceitaDto>> GetReceitasAsync()
        {
            var receitas = await _context.Receitas.ToListAsync();

            return _mapper.Map<IEnumerable<ReceitaDto>>(receitas);
        }

        public async Task<ReceitaDto> GetReceitaByIdAsync(int id)
        {
            var receita = _mapper.Map<ReceitaDto>(await _context.Receitas.FindAsync(id));

            return receita;
        }

        public async Task<CreateReceitaDto?> UpdateReceitaAsync(int id, CreateReceitaDto receitaDto)
        {
            var receita = await _context.Receitas.FindAsync(id);

            if (receita is not null)
            {
                _mapper.Map(receitaDto, receita);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException e)
                {
                    throw e;
                }
                return receitaDto;
            }

            return null;
        }

        public async Task<bool> DeleteReceitaAsync(int id)
        {
            var receita = await _context.Receitas.FindAsync(id);

            if (receita is not null)
            {
                _context.Receitas.Remove(receita);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException e)
                {
                    throw e;
                }
                return true;
            }

            return false;
        }
    }
}