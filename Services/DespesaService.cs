using AutoMapper;
using challenge_backend_2.Data;
using challenge_backend_2.DTOs.Despesa;
using challenge_backend_2.Interfaces;
using challenge_backend_2.Models;
using Microsoft.EntityFrameworkCore;

namespace challenge_backend_2.Services
{
    public class DespesaService : IDespesaService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public DespesaService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Verifica(CreateDespesaDto despesaDto)
        {
            if (await _context.Despesas.AnyAsync(x => x.Descricao == despesaDto.Descricao
                && x.Data.Year == despesaDto.Data.Year
                && x.Data.Month == despesaDto.Data.Month))
            {
                return true;
            }
            else
                return false;

        }

        public async Task<CreateDespesaDto?> CreateDespesaAsync(CreateDespesaDto despesaDto)
        {
            if (await Verifica(despesaDto))
            {
                return null;
            }
            _context.Despesas.Add(_mapper.Map<Despesa>(despesaDto));
            await _context.SaveChangesAsync();
            return despesaDto;
        }

        public async Task<IEnumerable<DespesaDto>> GetDespesasAsync()
        {
            var despesas = await _context.Despesas.ToListAsync();

            return _mapper.Map<IEnumerable<DespesaDto>>(despesas);
        }

        public async Task<DespesaDto> GetDespesaByIdAsync(int id)
        {
            var despesa = _mapper.Map<DespesaDto>(await _context.Despesas.FindAsync(id));

            return despesa;
        }

        public async Task<CreateDespesaDto?> UpdateDespesaAsync(int id, CreateDespesaDto despesaDto)
        {
            var despesa = await _context.Despesas.FindAsync(id);

            if (despesa is not null)
            {
                _mapper.Map(despesaDto, despesa);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException e)
                {
                    throw e;
                }
            }

            return null;
        }

        public async Task<bool> DeleteDespesaAsync(int id)
        {
            var despesa = await _context.Despesas.FindAsync(id);

            if (despesa is not null)
            {
                _context.Despesas.Remove(despesa);
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