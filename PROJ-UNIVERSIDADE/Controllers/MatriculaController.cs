using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PROJ_UNIVERSIDADE.Contexts;
using PROJ_UNIVERSIDADE.Models;
using System.Data;

namespace PROJ_UNIVERSIDADE.Controllers
{
    public class MatriculaController(GlobalContext context) : Controller
    {
        private readonly GlobalContext _context = context;

        public IActionResult Index(ConsultaComIdentificacao consulta)
        {
            if (ModelState.IsValid)
            {
                if (consulta.Tipo != "0" && consulta.Identificacao != string.Empty)
                {
                    var resultado = _context.SP_BuscarInscrito(consulta);

                    if (resultado != null)
                    {
                        ViewBag.inscrito = resultado;
                        ViewBag.listarTiposPagamento = _context.SP_ListarTiposPagamento();
                    }
                    else
                    {
                        ViewBag.iconAlert = "failed";
                        ViewBag.messageAlert = "Candidato não encontrado";
                    }
                }
            }

            return View();
        }

        public IActionResult ConfirmarMatricula(int inscritoId)
        {
            if (ModelState.IsValid)
            {
                var InscritoID = new SqlParameter("@InscritoID", inscritoId);
                var mensagemParam = new SqlParameter
                {
                    ParameterName = "@Mensagem",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 255,
                    Direction = ParameterDirection.Output
                };

                _context.Database.ExecuteSqlRaw(
                    "EXEC SP_Efetuar_Matricula @InscritoID, @Mensagem",
                    InscritoID, mensagemParam
                );

                TempData["inscrito"] = inscritoId;

                return RedirectToAction("recibo");
            }

            ViewBag.iconAlert = "failed";
            ViewBag.messageAlert = "Matrícula não realizada";

            return View("Index");
        }

        public ActionResult Recibo()
        {
            if (TempData["inscrito"] == null) return RedirectToAction("index");

            var resultado = _context.SP_Matricula_Recibo(TempData["inscrito"]?.ToString());

            if (resultado == null) return RedirectToAction("index");

            ViewBag.recibo = resultado;

            return View();
        }

        public IActionResult Lista(ConsultaSemIdentificacao consulta)
        {
            if (ModelState.IsValid)
            {
                if (consulta.CampusID != -1 && consulta.CursoID != -1 && consulta.PeriodoID != -1)
                {
                    ViewBag.matriculados = _context.SP_ListarMatriculados(consulta);
                }
            }

            ViewBag.listarCampus = _context.SP_ListarCampus();
            ViewBag.listarPeriodos = _context.SP_ListarPeriodos();
            ViewBag.listarAnoLetivo = _context.SP_ListarAnoLetivo();

            if (consulta.CampusID != -1)
            {
                ViewBag.listarFaculdades = _context.SP_ListarFaculdadesPorCampus(consulta.CampusID);
            }

            if (consulta.FaculdadeID != -1)
            {
                ViewBag.listarCursos = _context.SP_ListarCursosPorFaculdade(consulta.FaculdadeID);
            }

            return View();
        }
    }
}
