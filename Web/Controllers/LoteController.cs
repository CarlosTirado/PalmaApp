using System.Collections.Generic;
using System.Threading.Tasks;
using Aplication.Cultivos;
using Aplication.Cultivos.ModelView;
using Aplication.Lotes;
using Aplication.Lotes.ModelView;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoteController : Controller
    {
        private readonly IMediator _mediator;

        public LoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCultivo/{cultivoId}")]
        public async Task<ActionResult<CultivoModelView>> GetCultivoId(long cultivoId)
        {
            var response = await _mediator.Send(new ConsultarCultivoPorIdRequest { CultivoId = cultivoId });
            return Ok(response.Cultivo);
        }

        [HttpGet("Cultivo/{cultivoId}")]
        public async Task<ActionResult<List<LoteModelView>>> GetsPorCultivoId(long cultivoId)
        {
            var response = await _mediator.Send(new ConsultarLotesRequest { CultivoId = cultivoId });
            return Ok(response.Lotes);
        }

        [HttpGet("")]
        public async Task<ActionResult<List<LoteModelView>>> Gets()
        {
            var response = await _mediator.Send(new ConsultarLotesRequest());
            return Ok(response.Lotes);
        }

        [HttpGet("{loteId}")]
        public async Task<ActionResult<LoteModelView>> Gets(long loteId)
        {
            var response = await _mediator.Send(new ConsultarLotePorIdRequest { LoteId = loteId });
            return Ok(response.Lote);
        }

        [HttpPost("")]
        public async Task<ActionResult<RegistrarLoteResponse>> Post(RegistrarLoteRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("")]
        public async Task<ActionResult<EditarLoteResponse>> Put(EditarLoteRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
