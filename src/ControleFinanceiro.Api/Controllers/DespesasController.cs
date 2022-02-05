using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Dtos.Despesa;
using ControleFinanceiro.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DespesasController : ControllerBase
{
    private readonly IDespesaService _service;

    public DespesasController(IDespesaService despesaService)
    {
        _service = despesaService;
    }

    [HttpPost]
    public async Task<ActionResult<RespostaDto<CreateDespesaDto>>> CreateDespesaAsync([FromBody]CreateDespesaDto despesaDto)
    {
        var despesa = await _service.CreateDespesaAsync(despesaDto);

        if (!despesa.Sucesso) 
            return BadRequest(despesa);
        else
            return Ok(despesa);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RespostaDto<RetornoDespesaDto>>> GetDespesaByIdAsync([FromRoute]int id)
    {
        var despesa = await _service.GetDespesaByIdAsync(id);

        if (!despesa.Sucesso) 
            return BadRequest(despesa);
        else
            return Ok(despesa);
    }

    [HttpGet]
    public async Task<ActionResult<RespostaDto<IEnumerable<RetornoDespesaDto>>>> GetDespesasAsync([FromQuery]string descricao)
    {
        var despesas = await _service.GetDespesasAsync(descricao);
        return Ok(despesas);
    }

    [HttpGet("{ano}/{mes}")]
    public async Task<ActionResult<RespostaDto<IEnumerable<RetornoDespesaDto>>>> GetDespesasByDateAsync([FromRoute]int ano, [FromRoute]int mes)
    {
        var despesas = await _service.GetDespesasByDateAsync(ano, mes);

        return Ok(despesas);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<RespostaDto<CreateDespesaDto>>> UpdateDespesaAsync([FromRoute]int id, [FromBody]CreateDespesaDto despesaDto)
    {
        var despesa = await _service.UpdateDespesaAsync(id, despesaDto);

        return Ok(despesa);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<RespostaDto>> DeleteDespesaAsync([FromRoute]int id)
    {
        var despesa = await _service.DeleteDespesaAsync(id);

        if (!despesa.Sucesso) 
            return BadRequest(despesa);
        else 
            return Ok();
    }
}