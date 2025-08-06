using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
                if (consulta.Tipo != "0" && consulta.Identificacao != string.Empty)
                {
                    ViewBag.inscrito = _context.SP_BuscarInscrito(consulta);

                    ViewBag.listarTiposPagamento = _context.SP_ListarTiposPagamento();
                }
            }

            return View();
        }

        public IActionResult PagamentoMatricula(PagamentoMatricula pagamento, int inscritoId)
        {
            if (ModelState.IsValid)
            {
                var BancoID = new SqlParameter("@BancoID", pagamento.BancoID);
                var InscritoID = new SqlParameter("@InscritoID", inscritoId);
                var DataPagamento = new SqlParameter("@DataPagamento", pagamento.DataPagamento);
                var HoraPagamento = new SqlParameter("@HoraPagamento", pagamento.HoraPagamento);
                var NumeroRecibo = new SqlParameter("@NumeroRecibo", pagamento.NumeroRecibo);
                var TipoPagamentoID = new SqlParameter("@TipoPagamentoID", pagamento.TipoPagamentoID);
                var Valor = new SqlParameter("@Valor", pagamento.Valor);

                _context.Database.ExecuteSqlRaw(
                    "EXEC SP_Efetuar_Pagamento_Matricula @InscritoID, @TipoPagamentoID, @BancoID, @NumeroRecibo, @Valor, @DataPagamento, @HoraPagamento",
                    InscritoID,
                    TipoPagamentoID,
                    BancoID,
                    NumeroRecibo,
                    Valor,
                    DataPagamento,
                    HoraPagamento
                );

                return RedirectToAction("Index");
            }

            if (pagamento.TipoPagamentoID != -1)
            {
                ViewBag.listarBancos = _context.SP_Listar_Bancos(pagamento.TipoPagamentoID);
            }

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
