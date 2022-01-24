using challenge_backend_2.Data;
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

        public ReceitasController(DataContext dataContext)
        {
            _context = dataContext;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarReceitaAsync([FromBody] Receita receita)
        {
            if (await _context.Receitas.AnyAsync(x => 
                x.Descricao == receita.Descricao &&
                x.Data.Month == receita.Data.Month))
            {
                return Ok(new {message = $"Já existe uma receita com descrição '{receita.Descricao}' para o mês {receita.Data.Month}"});
            }
            else
            {
            _context.Receitas.Add(receita);
            await _context.SaveChangesAsync();
            return Ok(receita);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetReceitasAsync()
        {
            var receitas = await _context.Receitas.ToListAsync();
            return Ok(receitas);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReceitaByIdAsync([FromRoute]int id)
        {
            var receita = await _context.Receitas.FindAsync(id);

            if (receita != null)
                return Ok(receita);
                
            return NotFound(new{message = "Receita informada não encontrada"});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReceitaAsync([FromRoute]int id, [FromBody] Receita att)
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
                    return NotFound(new {message = "Receita não encontrada"});
                else
                    throw e;
            }

            return Ok(att);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DelReceitaAsync([FromRoute]int id)
        {
            var receita = await _context.Receitas.FindAsync(id);

            if (receita is null) 
                return NotFound(new {message = "Receita não encontrada."});

            _context.Receitas.Remove(receita);
            await _context.SaveChangesAsync();
            return Ok(new {message = "Receita excluída com sucesso!"});
        }
    }
}