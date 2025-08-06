using Microsoft.AspNetCore.Mvc;
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
    }
}
