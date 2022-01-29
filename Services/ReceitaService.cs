using AutoMapper;
using challenge_backend_2.Data;
using challenge_backend_2.DTOs;
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

        public async Task<RespostaDto<CreateReceitaDto>> CreateReceitaAsync(CreateReceitaDto receitaDto)
        {
            var resposta = new RespostaDto<CreateReceitaDto>();
            
            if (await Verifica(receitaDto))
            {
                resposta.Sucess = false;
                resposta.Alertas.Add($"Já existe um receita com a descrição para o mês {receitaDto.Data.Month}/{receitaDto.Data.Year}.");

                return resposta;
            }
                
            _context.Receitas.Add(_mapper.Map<Receita>(receitaDto));
            await _context.SaveChangesAsync();
            
            resposta.Conteudo = receitaDto;
            resposta.Alertas.Add("Receita criada com sucesso.");

            return resposta;
        }

        public async Task<RespostaDto<IEnumerable<ReceitaDto>>> GetReceitasAsync(string? descricao)
        {
            var resposta = new RespostaDto<IEnumerable<ReceitaDto>>();
            var receitas = new List<Receita>();

            if (string.IsNullOrEmpty(descricao))
                receitas = await _context.Receitas.ToListAsync();
            else
                receitas = await _context.Receitas.Where(x => x.Descricao.Contains(descricao)).ToListAsync();

            if (receitas.Any() is false)
            {
                resposta.Sucess = false;
                resposta.Alertas.Add("Não foi encontrada nenhuma receita.");
                return resposta;
            }


            resposta.Conteudo = _mapper.Map<IEnumerable<ReceitaDto>>(receitas);
            resposta.Alertas.Add($"Foi encontrado um total de {receitas.Count()} receita(s).");

            return resposta;
        }

        public async Task<RespostaDto<IEnumerable<ReceitaDto>>> GetReceitasByDateAsync(int ano, int mes)
        {
            var resposta = new RespostaDto<IEnumerable<ReceitaDto>>();
            var receitas = await _context.Receitas.Where(x => x.Data.Year.Equals(ano) && x.Data.Month.Equals(mes)).ToListAsync();

            if (receitas is null)
            {
                resposta.Sucess = false;
                resposta.Alertas.Add("Não foi encontrada nenhuma receita para o período selecionado.");
                return resposta;
            }

            resposta.Conteudo = _mapper.Map<IEnumerable<ReceitaDto>>(receitas);
            resposta.Alertas.Add($"Foi encontrado um total de {receitas.Count()} receita(s).");

            return resposta;
        }

        public async Task<RespostaDto<ReceitaDto>> GetReceitaByIdAsync(int id)
        {
            var resposta = new RespostaDto<ReceitaDto>();
            var receita = await _context.Receitas.FindAsync(id);

            if (receita is null)
            {
                resposta.Sucess = false;
                resposta.Alertas.Add("Não foi encontrada a receita com o ID informado.");
            }

            resposta.Conteudo = _mapper.Map<ReceitaDto>(receita);

            return resposta;
        }

        public async Task<RespostaDto<CreateReceitaDto>> UpdateReceitaAsync(int id, CreateReceitaDto receitaDto)
        {
            var resposta = new RespostaDto<CreateReceitaDto>();
            var receita = await _context.Receitas.FindAsync(id);
            

            if (receita is not null && !await Verifica(receitaDto))
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
                resposta.Conteudo = receitaDto;
                return resposta;
            } 

            else if (receita is not null && await Verifica(receitaDto))
            {
                resposta.Sucess = false;
                resposta.Alertas.Add("Não é possivel atualizar, pois ja existe uma receita com a mesma " 
                            + $"descrição para o mês {receitaDto.Data.Month}/{receitaDto.Data.Year}.");
                return resposta;
            }
            
            else
            {
                resposta.Sucess = false;
                resposta.Alertas.Add("Não foi encontrada nenhuma receita para o ID informado para que seja atualizada.");
                
                return resposta;
            }
        }

        public async Task<RespostaDto> DeleteReceitaAsync(int id)
        {
            var resposta = new RespostaDto();
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
                
                resposta.Alertas.Add("Receita removida com sucesso!");
                return resposta;
            }

            resposta.Sucess = false;
            resposta.Alertas.Add("O ID informado não corresponde a nenhuma receita existente.");

            return resposta;
        }
    }
}