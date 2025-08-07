using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PROJ_UNIVERSIDADE.Contexts;
using PROJ_UNIVERSIDADE.Models;

namespace PROJ_UNIVERSIDADE.Controllers
{
    public class FinancasController(GlobalContext context) : Controller
    {
        private readonly GlobalContext _context = context;

        public IActionResult Consulta(ConsultaFinancaServico consulta)
        {
            if (ModelState.IsValid)
            {
                if (consulta.TipoPagamentoID != -1 && consulta.BancoID != -1 && consulta.TipoServico != -1)
                {
                    ViewBag.totalPago = _context.SP_TotalPago(consulta);
                }

                ViewBag.listarTiposPagamento = _context.SP_ListarTiposPagamento();

                if (consulta.TipoPagamentoID != -1 && consulta.BancoID != 0)
                {
                    ViewBag.listarBancos = _context.SP_Listar_Bancos(consulta.TipoPagamentoID);
                }
            }
            return View();
        }

        public IActionResult Inscricao(ConsultaComIdentificacao consulta)
        {
            if (ModelState.IsValid)
            {
                if (consulta.Tipo != "0" && consulta.Identificacao != string.Empty)
                {
                    var resultado = _context.SP_BuscarPreInscritoPagamento(consulta);

                    if (resultado != null)
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

                _context.Database.ExecuteSqlRaw(
                    "EXEC SP_Efetuar_Pagamento_Inscricao @CandidaturaID, @TipoPagamentoID, @BancoID, @NumeroRecibo, @DataPagamento, @HoraPagamento",
                    CandidaturaID,
                    TipoPagamentoID,
                    BancoID,
                    NumeroRecibo,
                    DataPagamento,
                    HoraPagamento
                );

                ViewBag.messageAlert = "Pagamento realizado com sucesso";

                return View("inscricao");
            }

            if (pagamento.TipoPagamentoID != -1)
            {
                ViewBag.listarBancos = _context.SP_Listar_Bancos(pagamento.TipoPagamentoID);
            }

            ViewBag.iconAlert = "failed";
            ViewBag.messageAlert = "Erro ao realizar o pagamento";

            return View("inscricao");
        }

        public IActionResult Matricula(ConsultaComIdentificacao consulta)
        {
            if (ModelState.IsValid)
            {
                if (consulta.Tipo != "0" && consulta.Identificacao != string.Empty)
                {
                    var resultado = _context.SP_BuscarInscritoPagamento(consulta);

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

                _context.Database.ExecuteSqlRaw(
                    "EXEC SP_Efetuar_Pagamento_Matricula @InscritoID, @TipoPagamentoID, @BancoID, @NumeroRecibo, @DataPagamento, @HoraPagamento",
                    InscritoID,
                    TipoPagamentoID,
                    BancoID,
                    NumeroRecibo,
                    DataPagamento,
                    HoraPagamento
                );

                ViewBag.messageAlert = "Pagamento realizado com sucesso";

                return View("matricula");
            }

            if (pagamento.TipoPagamentoID != -1)
            {
                ViewBag.listarBancos = _context.SP_Listar_Bancos(pagamento.TipoPagamentoID);
            }

            ViewBag.iconAlert = "failed";
            ViewBag.messageAlert = "Erro ao realizar o pagamento";

            return View("matricula");
        }
    }
}
