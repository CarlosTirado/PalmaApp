using System;
using System.Collections.Generic;
using System.IO;
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

        [HttpGet("Identificacion/{identificacion}")]
        public ActionResult<TerceroModelView> Get(string identificacion)
        {
            var response = _mediator.Send(new ConsultarTerceroQueryRequest(identificacion));
            return Ok(response.Result.Tercero);
        }
        [HttpGet("Correo/{correo}")]
        public ActionResult<TerceroModelView> GetPorCorreo(string correo)
        {
            var response = _mediator.Send(new ConsultarTerceroPorCorreoQueryRequest(correo));
            return Ok(response.Result.Tercero);
        }


        [HttpGet("PruebaEscribir")]
        public string PruebaEscribir()
        {
            try
            {
                StreamWriter sw = new StreamWriter("C:\\Test.txt", true);
                sw.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}: Hello World!!");
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Finalizado");
            }

            return "Correcto!!"; 
        }
    }
}
