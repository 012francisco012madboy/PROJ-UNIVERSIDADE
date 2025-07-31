using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJ_UNIVERSIDADE.Contexts;
using PROJ_UNIVERSIDADE.Models;

namespace PROJ_UNIVERSIDADE.Controllers
{
    public class MatriculaController(GlobalContext context) : Controller
    {
        private readonly GlobalContext _context = context;

        public IActionResult Index(ConsultaComIdentificacao consulta)
        {
            if (ModelState.IsValid)
            {
                ViewBag.preInscrito = _context.SP_BuscarPreInscrito(consulta);
            }

            return View();
        }
    }
}
