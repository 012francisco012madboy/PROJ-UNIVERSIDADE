using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PROJ_UNIVERSIDADE.Contexts;
using PROJ_UNIVERSIDADE.Models;
using System.Data;

namespace PROJ_UNIVERSIDADE.Controllers
{
    public class InscricaoController(GlobalContext context) : Controller
    {
        private readonly GlobalContext _context = context;

        public IActionResult Index(ConsultaComIdentificacao consulta)
        {
            if (ModelState.IsValid)
            {
                if(consulta.Tipo != "0" && consulta.Identificacao != string.Empty)
                {
                    var resultado = _context.SP_BuscarPreInscrito(consulta);
                    
                    if(resultado != null)
                    {
                        ViewBag.preInscrito = resultado;
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

        public IActionResult ConfirmarInscricao(int candidatoId)
        {
            if (ModelState.IsValid)
            {
                var CandidaturaID = new SqlParameter("@CandidaturaID", candidatoId);
                var mensagemParam = new SqlParameter
                {
                    ParameterName = "@Mensagem",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 255,
                    Direction = ParameterDirection.Output
                };

                _context.Database.ExecuteSqlRaw(
                    "EXEC SP_Efetuar_Inscricao @CandidaturaID, @Mensagem",
                    CandidaturaID, mensagemParam
                );

                ViewBag.messageAlert = "Inscrição realizada com sucesso";

                return View("Index");
            }

            ViewBag.iconAlert = "failed";
            ViewBag.messageAlert = "Inscrição não realizada";

            return View("Index");
        }

        public IActionResult Lista(ConsultaSemIdentificacao consulta)
        {
            if (ModelState.IsValid)
            {
                if(consulta.CampusID != -1 && consulta.CursoID != -1 && consulta.PeriodoID != -1)
                {
                    ViewBag.inscritos = _context.SP_ListarInscritos(consulta);
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
