using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Dtos.Receita;
using ControleFinanceiro.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReceitasController : ControllerBase
{
    private readonly IReceitaService _service;

    public ReceitasController(IReceitaService receitaService)
    {
        _service = receitaService;
    }

    [HttpPost]
    public async Task<ActionResult<RespostaDto<CreateReceitaDto>>> CreateReceitaAsync([FromBody]CreateReceitaDto receitaDto)
    {
        var receita = await _service.CreateReceitaAsync(receitaDto);

        if (!receita.Sucesso) 
            return BadRequest(receita);
        else
            return Ok(receita);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RespostaDto<RetornoReceitaDto>>> GetReceitaByIdAsync([FromRoute]int id)
    {
        var receita = await _service.GetReceitaByIdAsync(id);

        if (!receita.Sucesso) 
            return BadRequest(receita);
        else
            return Ok(receita);
    }

    [HttpGet]
    public async Task<ActionResult<RespostaDto<IEnumerable<RetornoReceitaDto>>>> GetReceitasAsync([FromQuery]string descricao)
    {
        var receitas = await _service.GetReceitasAsync(descricao);
        return Ok(receitas);
    }

    [HttpGet("{ano}/{mes}")]
    public async Task<ActionResult<RespostaDto<IEnumerable<RetornoReceitaDto>>>> GetReceitasByDateAsync([FromRoute]int ano, [FromRoute]int mes)
    {
        var receitas = await _service.GetReceitasByDateAsync(ano, mes);

        return Ok(receitas);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<RespostaDto<CreateReceitaDto>>> UpdateReceitaAsync([FromRoute]int id, [FromBody]CreateReceitaDto receitaDto)
    {
        var receita = await _service.UpdateReceitaAsync(id, receitaDto);

        return Ok(receita);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<RespostaDto>> DeleteReceitaAsync([FromRoute]int id)
    {
        var receita = await _service.DeleteReceitaAsync(id);

        if (!receita.Sucesso) 
            return BadRequest(receita);
        else 
            return Ok();
    }  
}