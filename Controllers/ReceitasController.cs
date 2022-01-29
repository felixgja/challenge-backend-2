using challenge_backend_2.DTOs;
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
        public async Task<ActionResult<RespostaDto<CreateReceitaDto>>> CreateReceitaAsync([FromBody] CreateReceitaDto receitaDto)
        {
            var receita = await _service.CreateReceitaAsync(receitaDto);

            return Ok(receita);
        }

        [HttpGet]
        public async Task<ActionResult<RespostaDto<IEnumerable<ReceitaDto>>>> GetReceitasAsync([FromQuery]string? descricao)
        {
            var receitas = await _service.GetReceitasAsync(descricao);

            return Ok(receitas);
        }
        
        [HttpGet("{ano}/{mes}")]
        public async Task<ActionResult<RespostaDto<IEnumerable<ReceitaDto>>>> GetReceitasByDateAsync([FromRoute]int ano, [FromRoute]int mes)
        {
            var receitas = await _service.GetReceitasByDateAsync(ano, mes);

            return Ok(receitas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RespostaDto<ReceitaDto>>> GetReceitaByIdAsync([FromRoute]int id)
        {
            var receita = await _service.GetReceitaByIdAsync(id);

            return Ok(receita);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RespostaDto<CreateReceitaDto>>> UpdateReceitaAsync([FromRoute]int id, [FromBody] CreateReceitaDto receitaDto)
        {
            var receita = await _service.UpdateReceitaAsync(id, receitaDto);
            
            return Ok(receita);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RespostaDto>> DeleteReceitaAsync([FromRoute]int id)
        {
            var receita = await _service.DeleteReceitaAsync(id);

            if (receita.Sucess) 
                return Ok(receita);
            
            return NotFound(receita);
        }
    }
}