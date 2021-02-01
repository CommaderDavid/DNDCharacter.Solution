using Microsoft.AspNetCore.Mvc;

namespace DNDCharacter.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}