using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Dtos.Resumo;
using ControleFinanceiro.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResumoController : ControllerBase
{

    private readonly IResumoService _service;

    public ResumoController(IResumoService resumoService)
    {
        _service = resumoService;
    }

    [HttpGet("{ano}/{mes}")]
    public async Task<ActionResult<RespostaDto<ResumoDto>>> GetResultAsync([FromRoute]int ano, [FromRoute]int mes)
    {
        return Ok(await _service.GetResumoAsync(ano, mes));
    }
}