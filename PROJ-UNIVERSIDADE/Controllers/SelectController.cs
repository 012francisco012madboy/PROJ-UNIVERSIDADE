using Microsoft.AspNetCore.Mvc;
using PROJ_UNIVERSIDADE.Contexts;

namespace PROJ_UNIVERSIDADE.Controllers
{
    public class SelectController(GlobalContext context) : Controller
    {
        private readonly GlobalContext _context = context;

        public JsonResult ListarMunicipios(int idProvincia)
        {
            var municipios = _context.SP_ListarMunicipiosPorProvincia(idProvincia).ToList();

            return Json(municipios);
        }

        public JsonResult ListarCursosMedio(int idAreaFormacao)
        {
            var cursosMedios = _context.SP_ListarCursosMediosPorArea(idAreaFormacao).ToList();

            return Json(cursosMedios);
        }

        public JsonResult ListarFaculdades(int idCampus)
        {
            var faculdades = _context.SP_ListarFaculdadesPorCampus(idCampus).ToList();

            return Json(faculdades);
        }

        public JsonResult ListarCursosFaculdade(int idFaculdade)
        {
            var cursos = _context.SP_ListarCursosPorFaculdade(idFaculdade).ToList();

            return Json(cursos);
        }

        public JsonResult ListarBancos(int idTipoPagamento)
        {
            var bancos = _context.SP_Listar_Bancos(idTipoPagamento).ToList();

            return Json(bancos);
        }
    }
}
