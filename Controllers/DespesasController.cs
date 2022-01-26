using AutoMapper;
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
        private readonly IMapper _mapper;

        public DespesasController(IDespesaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<CreateDespesaDto>> CreateDespesaAsync([FromBody] CreateDespesaDto despesaDto)
        {
            if (await _service.Verifica(despesaDto))
                return Ok(new {message = $"Já existe uma despesa com descrição '{despesaDto.Descricao}' para o mês {despesaDto.Data.Month}"});

            var despesa = await _service.CreateDespesaAsync(despesaDto);

            return Ok(despesa);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DespesaDto>>> GetDespesasAsync()
        {
            var despesas = await _service.GetDespesasAsync();

            return Ok(despesas);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<DespesaDto>> GetDespesaByIdAsync([FromRoute]int id)
        {
            var despesa = await _service.GetDespesaByIdAsync(id);

            if (despesa is not null)
                return Ok(despesa);
                
            return NotFound(new {message = "Despesa informada não encontrada"});
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CreateDespesaDto>> UpdateDespesaAsync([FromRoute]int id, [FromBody] CreateDespesaDto despesaDto)
        {
            var despesa = await _service.UpdateDespesaAsync(id, despesaDto);

            if(despesa is null)
                return NotFound(new {message = "Despesa não encontrada"});
            
            return Ok(despesaDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDespesaAsync([FromRoute]int id)
        {
            var despesa = await _service.DeleteDespesaAsync(id);

            if (despesa is true) 
                return Ok(new {message = "Despesa excluída com sucesso!"});
            
            return NotFound(new {message = "Despesa não encontrada."});
        }
    }
}