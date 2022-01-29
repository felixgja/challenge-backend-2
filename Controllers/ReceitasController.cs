using challenge_backend_2.DTOs.Receita;
using challenge_backend_2.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace challenge_backend_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceitasController : ControllerBase
    {
        private readonly IReceitaService _service;

        public ReceitasController(IReceitaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<CreateReceitaDto>> CreateReceitaAsync([FromBody] CreateReceitaDto receitaDto)
        {
            if (await _service.Verifica(receitaDto))
                return Ok(new {message = $"Já existe uma receita com descrição '{receitaDto.Descricao}' para o mês {receitaDto.Data.Month}"});

            var receita = await _service.CreateReceitaAsync(receitaDto);

            return Ok(receita);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceitaDto>>> GetReceitasAsync([FromQuery]string? descricao)
        {
            var receitas = await _service.GetReceitasAsync(descricao);

            return Ok(receitas);
        }

        [HttpGet("{ano}/{mes}")]
        public async Task<ActionResult<IEnumerable<ReceitaDto>>> GetReceitasByDateAsync([FromRoute]int ano, [FromRoute]int mes)
        {
            var receitas = await _service.GetReceitasByDateAsync(ano, mes);

            return Ok(receitas);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ReceitaDto>> GetReceitaByIdAsync([FromRoute]int id)
        {
            var receita = await _service.GetReceitaByIdAsync(id);

            if (receita is not null)
                return Ok(receita);
                
            return NotFound(new {message = "Receita informada não encontrada"});
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CreateReceitaDto>> UpdateReceitaAsync([FromRoute]int id, [FromBody] CreateReceitaDto receitaDto)
        {
            var receita = await _service.UpdateReceitaAsync(id, receitaDto);

            if(receita is null)
                return NotFound(new {message = "Receita não encontrada"});
            
            return Ok(receitaDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReceitaAsync([FromRoute]int id)
        {
            var receita = await _service.DeleteReceitaAsync(id);

            if (receita is true) 
                return Ok(new {message = "Receita excluída com sucesso!"});
            
            return NotFound(new {message = "Receita não encontrada."});
        }
    }
}