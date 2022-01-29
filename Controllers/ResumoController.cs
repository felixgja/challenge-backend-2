using challenge_backend_2.DTOs.Resumo;
using challenge_backend_2.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace challenge_backend_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResumoController : ControllerBase
    {
        private readonly IResumoService _service;

        public ResumoController(IResumoService service)
        {
            _service = service;
        }

        [HttpGet("{ano}/{mes}")]
        public async Task<ActionResult<ResumoDto>> GetResumoAsync([FromRoute]int ano, [FromRoute]int mes)
        {
            var resumo = await _service.GetResumoAsync(ano, mes);

            return Ok(resumo);
        }
    }
}