using challenge_backend_2.DTOs;
using challenge_backend_2.DTOs.Despesa;
using challenge_backend_2.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace challenge_backend_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DespesasController : ControllerBase
    {
        private readonly IDespesaService _service;

        public DespesasController(IDespesaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<RespostaDto<CreateDespesaDto>>> CreateDespesaAsync([FromBody] CreateDespesaDto despesaDto)
        {
            var despesa = await _service.CreateDespesaAsync(despesaDto);

            return Ok(despesa);
        }

        [HttpGet]
        public async Task<ActionResult<RespostaDto<IEnumerable<DespesaDto>>>> GetDespesasAsync([FromQuery]string? descricao)
        {
            var despesas = await _service.GetDespesasAsync(descricao);

            return Ok(despesas);
        }
        
        [HttpGet("{ano}/{mes}")]
        public async Task<ActionResult<RespostaDto<IEnumerable<DespesaDto>>>> GetDespesasByDateAsync([FromRoute]int ano, [FromRoute]int mes)
        {
            var despesas = await _service.GetDespesasByDateAsync(ano, mes);

            return Ok(despesas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RespostaDto<DespesaDto>>> GetDespesaByIdAsync([FromRoute]int id)
        {
            var despesa = await _service.GetDespesaByIdAsync(id);

            return Ok(despesa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RespostaDto<CreateDespesaDto>>> UpdateDespesaAsync([FromRoute]int id, [FromBody] CreateDespesaDto despesaDto)
        {
            var despesa = await _service.UpdateDespesaAsync(id, despesaDto);
            
            return Ok(despesa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RespostaDto>> DeleteDespesaAsync([FromRoute]int id)
        {
            var despesa = await _service.DeleteDespesaAsync(id);

            if (despesa.Sucess) 
                return Ok(despesa);
            
            return NotFound(despesa);
        }
    }
}