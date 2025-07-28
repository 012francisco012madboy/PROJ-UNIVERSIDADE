using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PROJ_UNIVERSIDADE.Contexts;
using PROJ_UNIVERSIDADE.Models;

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
            ViewBag.listarAnoLetivo = _context.SP_ListarAnoLetivo();
            ViewBag.listarMedias = _context.CarregarMedias();
            ViewBag.listarClasses = _context.SP_ListarClasses();
            ViewBag.listarCampus = _context.SP_ListarCampus();
            return View();
        }

        public IActionResult Candidatar(Candidatura candidatura)
        {
            var NomeCompleto = new SqlParameter("@NomeCompleto", candidatura.NomeCompleto);
            var NacionalidadeID = new SqlParameter("@NacionalidadeID", candidatura.NacionalidadeID);
            var SexoID = new SqlParameter("@SexoID", candidatura.SexoID);
            var EstadoCivilID = new SqlParameter("@EstadoCivilID", candidatura.EstadoCivilID);
            var DataNascimento = new SqlParameter("@DataNascimento", candidatura.DataNascimento);

            var TipoDocumentoID = new SqlParameter("@TipoDocumentoID", candidatura.TipoDocumentoID);
            var NumeroDocumento = new SqlParameter("@NumeroDocumento", candidatura.NumeroDocumento);
            var DataEmissao = new SqlParameter("@DataEmissao", candidatura.DataEmissao);
            var DataValidade = new SqlParameter("@DataValidade", candidatura.DataValidade);

            var Telefone = new SqlParameter("@Telefone", candidatura.Telefone);
            var Email = new SqlParameter("@Email", candidatura.Email);
            var Morada = new SqlParameter("@Morada", candidatura.Morada);
                
            var MunicipioID = new SqlParameter("@MunicipioID", candidatura.MunicipioID);
                
            var NomePai = new SqlParameter("@NomePai", candidatura.NomePai);
            var NomeMae = new SqlParameter("@NomeMae", candidatura.NomeMae);
                
            var CursoMedioID = new SqlParameter("@CursoMedioID", candidatura.CursoMedioID);
            var AnoConclusao = new SqlParameter("@AnoConclusao", candidatura.AnoConclusao);
            var MediaFinal = new SqlParameter("@MediaFinal", candidatura.MediaFinal);
            var ClasseID = new SqlParameter("@ClasseID", candidatura.ClasseID);
            var InstituicaoEscolar = new SqlParameter("@InstituicaoEscolar", candidatura.InstituicaoEscolar);
                
            var CampusID = new SqlParameter("@CampusID", candidatura.CampusID);
            var CursoID = new SqlParameter("@CursoID", candidatura.CursoID);
            var PeriodoID = new SqlParameter("@PeriodoID", candidatura.PeriodoID);
            var AnoLetivoID = new SqlParameter("@AnoLetivoID", 1); //pegar o novo ano letivo
            var Observacao = new SqlParameter("@Observacao", candidatura.Observacao);

            _context.Database.ExecuteSqlRaw(
                "EXEC SP_InscreverPessoa @NomeCompleto, @NacionalidadeID, @SexoID, @EstadoCivilID, @DataNascimento, @TipoDocumentoID, @NumeroDocumento, @DataEmissao, @DataValidade, @Telefone, @Email, @Morada, @MunicipioID, @NomePai, @NomeMae, @CursoMedioID, @AnoConclusao, @MediaFinal, @ClasseID, @InstituicaoEscolar, @CampusID, @CursoID, @PeriodoID, @AnoLetivoID, @Observacao",
                NomeCompleto, NacionalidadeID, SexoID, EstadoCivilID, DataNascimento,
                TipoDocumentoID, NumeroDocumento, DataEmissao, DataValidade,
                Telefone, Email, Morada, MunicipioID,
                NomePai, NomeMae,
                CursoMedioID, AnoConclusao, MediaFinal, ClasseID, InstituicaoEscolar,
                CampusID, CursoID, PeriodoID, AnoLetivoID, Observacao
            );

            return RedirectToAction("Index");
        }
    }
}
