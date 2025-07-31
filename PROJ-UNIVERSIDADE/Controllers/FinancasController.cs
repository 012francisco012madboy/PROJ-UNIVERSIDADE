using Microsoft.AspNetCore.Mvc;

namespace PROJ_UNIVERSIDADE.Controllers
{
    public class FinancasController : Controller
    {
        public IActionResult Pagamento()
        {
            return View();
        }
    }
}
