using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class TestS3 : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}