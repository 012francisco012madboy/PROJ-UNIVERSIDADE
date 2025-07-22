using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROJ_UNIVERSIDADE.Contexts;

namespace PROJ_UNIVERSIDADE.Controllers
{
    public class InscricaoProcedure(SelectProcedure context) : Controller
    {
        private readonly SelectProcedure _context = context;

        // GET: CampusController
        public ActionResult Index()
        {

            ViewBag.listarCampi = _context.SP_ListarCampi();
            return View();
        }
    }
}
