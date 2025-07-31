using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PROJ_UNIVERSIDADE.Contexts;
using PROJ_UNIVERSIDADE.Models;

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
                    ViewBag.preInscrito = _context.SP_BuscarPreInscrito(consulta);
                }

                ViewBag.listarTiposPagamento = _context.SP_ListarTiposPagamento();
            }

            return View();
        }

        public IActionResult PagamentoInscricao(PagamentoInscricao pagamento, int candidatoId)
        {
            if (ModelState.IsValid)
            {
                var BancoID = new SqlParameter("@BancoID", pagamento.BancoID);
                var CandidaturaID = new SqlParameter("@CandidaturaID", candidatoId);
                var DataPagamento = new SqlParameter("@DataPagamento", pagamento.DataPagamento);
                var HoraPagamento = new SqlParameter("@HoraPagamento", pagamento.HoraPagamento);
                var NumeroRecibo = new SqlParameter("@NumeroRecibo", pagamento.NumeroRecibo);
                var TipoPagamentoID = new SqlParameter("@TipoPagamentoID", pagamento.TipoPagamentoID);
                var Valor = new SqlParameter("@Valor", pagamento.Valor);

                _context.Database.ExecuteSqlRaw(
                    "EXEC SP_Efetuar_Pagamento_Inscricao @CandidaturaID, @TipoPagamentoID, @BancoID, @NumeroRecibo, @Valor, @DataPagamento, @HoraPagamento",
                    CandidaturaID,
                    TipoPagamentoID,
                    BancoID,
                    NumeroRecibo,
                    Valor,
                    DataPagamento,
                    HoraPagamento
                );
            }

            return RedirectToAction("Index");
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

            return View();
        }
    }
}
