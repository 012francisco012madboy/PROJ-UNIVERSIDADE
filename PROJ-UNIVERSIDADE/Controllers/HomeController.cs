using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJ_UNIVERSIDADE.Contexts;

namespace PROJ_UNIVERSIDADE.Controllers
{
    public class HomeController(GlobalContext context) : Controller
    {
        private readonly GlobalContext _context = context;

        public IActionResult Index()
        {
            int totalPreInscritos = _context.SP_TotalPreInscritos();
            int totalInscritos = _context.SP_TotalInscritos();
            int totalMatriculados = _context.SP_TotalMatriculados();

            ViewBag.totalPreInscritos = totalPreInscritos;
            ViewBag.totalInscritos = totalInscritos;
            ViewBag.totalMatriculados = totalMatriculados;
            return View();
        }
    }
}
