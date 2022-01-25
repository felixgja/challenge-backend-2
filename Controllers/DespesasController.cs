using AutoMapper;
using challenge_backend_2.Data;
using challenge_backend_2.DTOs.Despesa;
using challenge_backend_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace challenge_backend_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DespesasController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public DespesasController(DataContext dataContext, IMapper mapper)
        {
            _context = dataContext;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<CreateDespesaDto>> CreateDespesaAsync([FromBody] CreateDespesaDto despesaDto)
        {
            if (await _context.Despesas.AnyAsync(x => 
                x.Descricao == despesaDto.Descricao &&
                x.Data.Month == despesaDto.Data.Month))
            {
                return Ok(new {message = $"Já existe uma despesa com descrição '{despesaDto.Descricao}' para o mês {despesaDto.Data.Month}"});
            }
            else
            {
                _context.Despesas.Add(_mapper.Map<Despesa>(despesaDto));
                await _context.SaveChangesAsync();
                return Ok(despesaDto);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadDespesaDto>>> GetDespesasAsync()
        {
            var despesas = await _context.Despesas.ToListAsync();

            return Ok(despesas);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadDespesaDto>> GetDespesaByIdAsync([FromRoute]int id)
        {
            var despesa = _mapper.Map<ReadDespesaDto>(await _context.Despesas.FindAsync(id));

            if (despesa is not null)
                return Ok(despesa);
                
            return NotFound(new {message = "Despesa informada não encontrada"});
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateDespesaDto>> UpdateDespesaAsync([FromRoute]int id, [FromBody] UpdateDespesaDto despesaDto)
        {
            var despesa = await _context.Despesas.FindAsync(id);

            if(await _context.Despesas.AnyAsync(x => x.Id == id) is false)
                    return NotFound(new {message = "Despesa não encontrada"});
            
            _mapper.Map(despesaDto, despesa);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw e;
            }

            return Ok(despesaDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAsync([FromRoute]int id)
        {
            var despesa = await _context.Despesas.FindAsync(id);

            if (despesa is null) 
                return NotFound(new {message = "Despesa não encontrada."});
            
                _context.Despesas.Remove(despesa);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw e;
            }
            
            return Ok(new {message = "Despesa excluída com sucesso!"});
        }
    }
}