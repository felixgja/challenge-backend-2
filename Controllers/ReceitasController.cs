using AutoMapper;
using challenge_backend_2.Data;
using challenge_backend_2.DTOs.Receita;
using challenge_backend_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace challenge_backend_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceitasController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ReceitasController(DataContext dataContext, IMapper mapper)
        {
            _context = dataContext;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<CreateReceitaDto>> CreateReceitaAsync([FromBody] CreateReceitaDto receitaDto)
        {
            if (await _context.Receitas.AnyAsync(x => 
                x.Descricao == receitaDto.Descricao &&
                x.Data.Month == receitaDto.Data.Month))
            {
                return Ok(new {message = $"Já existe uma receitaDto com descrição '{receitaDto.Descricao}' para o mês {receitaDto.Data.Month}"});
            }
            else
            {
                _context.Receitas.Add(_mapper.Map<Receita>(receitaDto));
                await _context.SaveChangesAsync();
                return Ok(receitaDto);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadReceitaDto>>> GetReceitasAsync()
        {
            var receitas = _mapper.Map<IEnumerable<ReadReceitaDto>>(await _context.Receitas.ToListAsync());
            return Ok(receitas);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadReceitaDto>> GetReceitaByIdAsync([FromRoute]int id)
        {
            var receita = _mapper.Map<ReadReceitaDto>(await _context.Receitas.FindAsync(id));

            if (receita is not null)
                return Ok(receita);
                
            return NotFound(new{message = "Receita informada não encontrada"});
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateReceitaDto>> UpdateReceitaAsync([FromRoute]int id, [FromBody] UpdateReceitaDto receitaDto)
        {
            var receita = await _context.Receitas.FindAsync(id);
        
            if(await _context.Despesas.AnyAsync(x => x.Id == id) is false)
                return NotFound(new {message = "Receita não encontrada"});

            _mapper.Map(receitaDto, receita);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw e;
            }

            return Ok(receitaDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DelReceitaAsync([FromRoute]int id)
        {
            var receita = await _context.Receitas.FindAsync(id);

            if (receita is null) 
                return NotFound(new {message = "Receita não encontrada."});

            _context.Receitas.Remove(receita);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw e;
            }
            return Ok(new {message = "Receita excluída com sucesso!"});
        }
    }
}