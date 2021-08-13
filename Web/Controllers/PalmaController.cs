using System.Collections.Generic;
using System.Threading.Tasks;
using Aplication.Cultivos;
using Aplication.Cultivos.ModelView;
using Aplication.Lotes;
using Aplication.Lotes.ModelView;
using Aplication.Palmas;
using Aplication.Palmas.ModelView;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalmaController : Controller
    {
        private readonly IMediator _mediator;

        public PalmaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCultivo/{cultivoId}")]
        public async Task<ActionResult<CultivoModelView>> GetCultivoId(long cultivoId)
        {
            var response = await _mediator.Send(new ConsultarCultivoPorIdRequest { CultivoId = cultivoId });
            return Ok(response.Cultivo);
        }

        [HttpGet("GetLote/{loteId}")]
        public async Task<ActionResult<LoteModelView>> GetLoteId(long loteId)
        {
            var response = await _mediator.Send(new ConsultarLotePorIdRequest { LoteId = loteId });
            return Ok(response.Lote);
        }

        [HttpGet("Lote/{loteId}")]
        public async Task<ActionResult<List<PalmaModelView>>> GetsPorLoteId(long loteId)
        {
            var response = await _mediator.Send(new ConsultarPalmasRequest { LoteId = loteId });
            return Ok(response.Palmas);
        }


        [HttpGet("{PalmaId}")]
        public async Task<ActionResult<PalmaModelView>> Gets(long PalmaId)
        {
            var response = await _mediator.Send(new ConsultarPalmaPorIdRequest { PalmaId = PalmaId });
            return Ok(response.Palma);
        }

        [HttpPost("")]
        public async Task<ActionResult<RegistrarPalmaResponse>> Post(RegistrarPalmaRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("")]
        public async Task<ActionResult<EditarPalmaResponse>> Put(EditarPalmaRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
