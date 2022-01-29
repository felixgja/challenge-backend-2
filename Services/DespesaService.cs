using AutoMapper;
using challenge_backend_2.Data;
using challenge_backend_2.DTOs;
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

        public async Task<RespostaDto<CreateDespesaDto>> CreateDespesaAsync(CreateDespesaDto despesaDto)
        {
            var resposta = new RespostaDto<CreateDespesaDto>();
            
            if (await Verifica(despesaDto))
            {
                resposta.Sucess = false;
                resposta.Alertas.Add($"Já existe um despesa com a descrição para o mês {despesaDto.Data.Month}/{despesaDto.Data.Year}.");

                return resposta;
            }
                
            _context.Despesas.Add(_mapper.Map<Despesa>(despesaDto));
            await _context.SaveChangesAsync();
            
            resposta.Conteudo = despesaDto;
            resposta.Alertas.Add("Despesa criada com sucesso.");

            return resposta;
        }

        public async Task<RespostaDto<IEnumerable<DespesaDto>>> GetDespesasAsync(string? descricao)
        {
            var resposta = new RespostaDto<IEnumerable<DespesaDto>>();
            var despesas = new List<Despesa>();

            if (string.IsNullOrEmpty(descricao))
                despesas = await _context.Despesas.ToListAsync();
            else
                despesas = await _context.Despesas.Where(x => x.Descricao.Contains(descricao)).ToListAsync();

            if (despesas.Any() is false)
            {
                resposta.Sucess = false;
                resposta.Alertas.Add("Não foi encontrada nenhuma despesa.");
                return resposta;
            }


            resposta.Conteudo = _mapper.Map<IEnumerable<DespesaDto>>(despesas);
            resposta.Alertas.Add($"Foi encontrado um total de {despesas.Count()} despesa(s).");

            return resposta;
        }

        public async Task<RespostaDto<IEnumerable<DespesaDto>>> GetDespesasByDateAsync(int ano, int mes)
        {
            var resposta = new RespostaDto<IEnumerable<DespesaDto>>();
            var despesas = await _context.Despesas.Where(x => x.Data.Year.Equals(ano) && x.Data.Month.Equals(mes)).ToListAsync();

            if (despesas is null)
            {
                resposta.Sucess = false;
                resposta.Alertas.Add("Não foi encontrada nenhuma despesa para o período selecionado.");
                return resposta;
            }

            resposta.Conteudo = _mapper.Map<IEnumerable<DespesaDto>>(despesas);
            resposta.Alertas.Add($"Foi encontrado um total de {despesas.Count()} despesa(s).");

            return resposta;
        }

        public async Task<RespostaDto<DespesaDto>> GetDespesaByIdAsync(int id)
        {
            var resposta = new RespostaDto<DespesaDto>();
            var despesa = await _context.Despesas.FindAsync(id);

            if (despesa is null)
            {
                resposta.Sucess = false;
                resposta.Alertas.Add("Não foi encontrada a despesa com o ID informado.");
            }

            resposta.Conteudo = _mapper.Map<DespesaDto>(despesa);

            return resposta;
        }

        public async Task<RespostaDto<CreateDespesaDto>> UpdateDespesaAsync(int id, CreateDespesaDto despesaDto)
        {
            var resposta = new RespostaDto<CreateDespesaDto>();
            var despesa = await _context.Despesas.FindAsync(id);
            

            if (despesa is not null && !await Verifica(despesaDto))
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
                resposta.Conteudo = despesaDto;
                return resposta;
            } 

            else if (despesa is not null && await Verifica(despesaDto))
            {
                resposta.Sucess = false;
                resposta.Alertas.Add("Não é possivel atualizar, pois ja existe uma despesa com a mesma " 
                            + $"descrição para o mês {despesaDto.Data.Month}/{despesaDto.Data.Year}.");
                return resposta;
            }
            
            else
            {
                resposta.Sucess = false;
                resposta.Alertas.Add("Não foi encontrada nenhuma despesa para o ID informado para que seja atualizada.");
                
                return resposta;
            }
        }

        public async Task<RespostaDto> DeleteDespesaAsync(int id)
        {
            var resposta = new RespostaDto();
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

                resposta.Alertas.Add("Despesa excluída com sucesso!");
                return resposta;
            }

            resposta.Sucess = false;
            resposta.Alertas.Add("O ID informado não corresponde a nenhuma despesa existente.");

            return resposta;
        }
    }
}