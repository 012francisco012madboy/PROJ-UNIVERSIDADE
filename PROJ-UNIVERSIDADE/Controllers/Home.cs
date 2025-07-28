using Microsoft.AspNetCore.Mvc;

namespace PROJ_UNIVERSIDADE.Controllers
{
    public class Home : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
