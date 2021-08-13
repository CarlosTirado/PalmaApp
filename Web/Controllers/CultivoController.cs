using System.Collections.Generic;
using System.Threading.Tasks;
using Aplication.Cultivos;
using Aplication.Cultivos.ModelView;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CultivoController : Controller
    {
        private readonly IMediator _mediator;

        public CultivoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        public async Task<ActionResult<List<CultivoModelView>>> Gets()
        {
            var response = await _mediator.Send(new ConsultarCultivosRequest());
            return Ok(response.Cultivos);
        }

        [HttpGet("{cultivoId}")]
        public async Task<ActionResult<CultivoModelView>> Gets(long cultivoId)
        {
            var response = await _mediator.Send(new ConsultarCultivoPorIdRequest { CultivoId = cultivoId });
            return Ok(response.Cultivo);
        }

        [HttpPost("")]
        public async Task<ActionResult<RegistrarCultivoResponse>> Post(RegistrarCultivoRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("")]
        public async Task<ActionResult<EditarCultivoResponse>> Put(EditarCultivoRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
