using challenge_backend_2.Data;
using challenge_backend_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace challenge_backend_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DespesasController : ControllerBase
    {
        private readonly DataContext _context;

        public DespesasController(DataContext dataContext)
        {
            _context = dataContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDespesaAsync([FromBody] Despesa despesa)
        {
            if (await _context.Despesas.AnyAsync(x => 
                x.Descricao == despesa.Descricao &&
                x.Data.Month == despesa.Data.Month))
            {
                return Ok(new {message = $"Já exister uma despesa com descrição '{despesa.Descricao}' para o mês {despesa.Data.Month}"});
            }
            else
            {
            _context.Despesas.Add(despesa);
            await _context.SaveChangesAsync();
            return Ok(despesa);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDespesasAsync()
        {
            var despesas = await _context.Despesas.ToListAsync();
            return Ok(despesas);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDespesaByIdAsync([FromRoute]int id)
        {
            var despesa = await _context.Despesas.FindAsync(id);

            if (despesa is not null)
                return Ok(despesa);
                
            return NotFound(new {message = "Despesa informada não encontrada"});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDespesaAsync([FromRoute]int id, [FromBody] Despesa att)
        {
            if (id != att.Id) 
                return BadRequest();

            _context.Entry(att).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                if(await _context.Despesas.AnyAsync(x => x.Id == id) is false)
                    return NotFound(new {message = "Despesa não encontrada"});
                else
                    throw e;
            }

            return Ok(att);
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