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
    public class TareasController : ControllerBase
    {

        private readonly IMediator _mediator;
        public TareasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<TareasController>
        [HttpGet]
        public async Task<ActionResult<List<TareaModelView>>> Gets()
        {
            var response = await _mediator.Send(new ConsultarTareasRequest());
            return Ok(response.Tareas);
        }

        // GET api/<TareasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TareasController>
        [HttpPost]
        public async Task<ActionResult<RegistrarTareaResponse>> Post(RegistrarTareaRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        // PUT api/<TareasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TareasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
