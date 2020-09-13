using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.DatosBasicos.Tercero;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerceroController : Controller
    {
        private readonly IMediator _mediator;

        public TerceroController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        public ActionResult<List<TerceroModelView>> Gets()
        {
            var response = _mediator.Send(new ConsultarTercerosQueryRequest());
            return Ok(response.Result.Terceros);
        }
    }
}
