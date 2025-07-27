using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROJ_UNIVERSIDADE.Contexts;

namespace PROJ_UNIVERSIDADE.Controllers
{
    public class CandidaturaController(GlobalContext context) : Controller
    {
        private readonly GlobalContext _context = context;

        public ActionResult Index()
        {
            ViewBag.listarNacionalidades = _context.SP_ListarNacionalidades();
            ViewBag.listarProvincias = _context.SP_ListarProvincias();
            ViewBag.listarSexos = _context.SP_ListarSexos();
            ViewBag.listarEstadosCivis = _context.SP_ListarEstadosCivis();
            ViewBag.listarTipoDocumentos = _context.SP_ListarTipoDocumentos();
            ViewBag.listarPeriodos = _context.SP_ListarPeriodos();
            ViewBag.listarAreasFormacao = _context.SP_ListarAreasFormacao();
            ViewBag.listarAnos = _context.CarregarUltimos10Anos();
            ViewBag.listarMedias = _context.CarregarMedias();
            ViewBag.listarClasses = _context.SP_ListarClasses();
            ViewBag.listarCampus = _context.SP_ListarCampus();
            return View();
        }
    }
}
