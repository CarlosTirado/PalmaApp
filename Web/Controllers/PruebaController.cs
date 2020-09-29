using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {
        [HttpGet("Sumar/{a}/{b}")]
        public int GetSuma(int a, int b)
        {
            return a + b;
        }
    }



    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public DateTime HoraInicial;


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            HoraInicial = DateTime.Now;
            // do something before the action executes
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // do something after the action executes
        }
    }
}
