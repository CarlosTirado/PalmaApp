using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Tareas;
using Aplication.Tareas.ModelView;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {

        private readonly IMediator _mediator;
        public TareaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<TareaController>
        [HttpGet]
        public async Task<ActionResult<List<TareaModelView>>> Gets()
        {
            var response = await _mediator.Send(new ConsultarTareasRequest());
            return Ok(response.Tareas);
        }

        // GET api/<TareaController>/5
        [HttpGet("{Tareaid}")]
        public async Task<ActionResult<TareaModelView>> Gets(long tareaId)
        {
            var response = await _mediator.Send(new ConsultarTareaPorIdRequest { TareaId = tareaId });
            return Ok(response.Tarea);
        }

        // POST api/<TareaController>
        [HttpPost("")]
        public async Task<ActionResult<RegistrarTareaResponse>> Post(RegistrarTareaRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        // PUT api/<TareaController>/5
       
        [HttpPut("")]
        public async Task<ActionResult<EditarTareaResponse>> Put(EditarTareaRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
