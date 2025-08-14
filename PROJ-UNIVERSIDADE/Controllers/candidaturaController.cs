using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PROJ_UNIVERSIDADE.Contexts;
using PROJ_UNIVERSIDADE.Models;
using System.Data;

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
            ViewBag.listarAreasFormacao = _context.SP_ListarAreasFormacao();
            ViewBag.listarAnos = _context.CarregarUltimos10Anos();
            ViewBag.listarMedias = _context.CarregarMedias();
            ViewBag.listarClasses = _context.SP_ListarClasses();
            ViewBag.listarCampus = _context.SP_ListarCampus();
            ViewBag.listarPeriodos = _context.SP_ListarPeriodos();

            return View();
        }

        public IActionResult Candidatar(Candidatura candidatura)
        {
            if (ModelState.IsValid)
            {
                var erro = CandidaturaValidacao.Validar(candidatura);
                if (erro != null)
                {
                    ViewBag.typeAlert = "0";
                    ViewBag.messageAlert = erro;

                    CarregarListasAuxiliares(candidatura);

                    return View("index");
                }

                var parameters = new[]
                {
                    new SqlParameter("@NomeCompleto", candidatura.NomeCompleto ?? (object)DBNull.Value),
                    new SqlParameter("@NacionalidadeID", candidatura.NacionalidadeID),
                    new SqlParameter("@SexoID", candidatura.SexoID),
                    new SqlParameter("@EstadoCivilID", candidatura.EstadoCivilID),
                    new SqlParameter("@DataNascimento", candidatura.DataNascimento),

                    new SqlParameter("@TipoDocumentoID", candidatura.TipoDocumentoID),
                    new SqlParameter("@NumeroDocumento", candidatura.NumeroDocumento),
                    new SqlParameter("@DataEmissao", candidatura.DataEmissao),
                    new SqlParameter("@DataValidade", candidatura.DataValidade),

                    new SqlParameter("@Telefone", string.IsNullOrWhiteSpace(candidatura.Telefone.ToString()) ? DBNull.Value : candidatura.Telefone),
                    new SqlParameter("@Email", string.IsNullOrWhiteSpace(candidatura.Email) ? DBNull.Value : candidatura.Email),
                    new SqlParameter("@Morada", string.IsNullOrWhiteSpace(candidatura.Morada) ? DBNull.Value : candidatura.Morada),

                    new SqlParameter("@MunicipioID", candidatura.MunicipioID),

                    new SqlParameter("@NomePai", string.IsNullOrWhiteSpace(candidatura.NomePai) ? DBNull.Value : candidatura.NomePai),
                    new SqlParameter("@NomeMae", string.IsNullOrWhiteSpace(candidatura.NomeMae) ? DBNull.Value : candidatura.NomeMae),

                    new SqlParameter("@CursoMedioID", candidatura.CursoMedioID),
                    new SqlParameter("@AnoConclusao", candidatura.AnoConclusao),
                    new SqlParameter("@MediaFinal", candidatura.MediaFinal),
                    new SqlParameter("@ClasseID", candidatura.ClasseID),
                    new SqlParameter("@InstituicaoEscolar", string.IsNullOrWhiteSpace(candidatura.InstituicaoEscolar) ? DBNull.Value : candidatura.InstituicaoEscolar),

                    new SqlParameter("@CampusID", candidatura.CampusID),
                    new SqlParameter("@CursoID", candidatura.CursoID),
                    new SqlParameter("@PeriodoID", candidatura.PeriodoID),
                    new SqlParameter("@Observacao", string.IsNullOrWhiteSpace(candidatura.Observacao) ? DBNull.Value : candidatura.Observacao)
                    {
                        SqlDbType = SqlDbType.NVarChar
                    },

                    new SqlParameter("@Estado", SqlDbType.Int) { Direction = ParameterDirection.Output },
                    new SqlParameter("@Mensagem", SqlDbType.NVarChar, 255) { Direction = ParameterDirection.Output }
                };

                _context.Database.ExecuteSqlRaw(@"
                    EXEC SP_InscreverPessoa 
                    @NomeCompleto = @NomeCompleto,
                    @NacionalidadeID = @NacionalidadeID,
                    @SexoID = @SexoID,
                    @EstadoCivilID = @EstadoCivilID,
                    @DataNascimento = @DataNascimento,
                    @TipoDocumentoID = @TipoDocumentoID,
                    @NumeroDocumento = @NumeroDocumento,
                    @DataEmissao = @DataEmissao,
                    @DataValidade = @DataValidade,
                    @Telefone = @Telefone,
                    @Email = @Email,
                    @Morada = @Morada,
                    @MunicipioID = @MunicipioID,
                    @NomePai = @NomePai,
                    @NomeMae = @NomeMae,
                    @CursoMedioID = @CursoMedioID,
                    @AnoConclusao = @AnoConclusao,
                    @MediaFinal = @MediaFinal,
                    @ClasseID = @ClasseID,
                    @InstituicaoEscolar = @InstituicaoEscolar,
                    @CampusID = @CampusID,
                    @CursoID = @CursoID,
                    @PeriodoID = @PeriodoID,
                    @Observacao = @Observacao,
                    @Estado = @Estado OUTPUT,
                    @Mensagem = @Mensagem OUTPUT",
                        parameters
                );

                var estado = parameters.First(each => each.ParameterName == "@Estado").Value?.ToString();
                var mensagem = parameters.First(each => each.ParameterName == "@Mensagem").Value?.ToString();

                ViewBag.typeAlert = estado;
                ViewBag.messageAlert = mensagem;

                if (estado == "1")
                {
                    TempData["documento"] = candidatura.NumeroDocumento;

                    return RedirectToAction("recibo");
                }

                CarregarListasAuxiliares(candidatura);

                return View("index");
            }

            ViewBag.iconAlert = "failed";
            ViewBag.messageAlert = "Preencha todos os campos";

            CarregarListasAuxiliares(candidatura);

            return View("index");
        }

        private void CarregarListasAuxiliares(Candidatura candidatura)
        {
            ViewBag.listarNacionalidades = _context.SP_ListarNacionalidades();
            ViewBag.listarProvincias = _context.SP_ListarProvincias();
            ViewBag.listarSexos = _context.SP_ListarSexos();
            ViewBag.listarEstadosCivis = _context.SP_ListarEstadosCivis();
            ViewBag.listarTipoDocumentos = _context.SP_ListarTipoDocumentos();
            ViewBag.listarAreasFormacao = _context.SP_ListarAreasFormacao();
            ViewBag.listarAnos = _context.CarregarUltimos10Anos();
            ViewBag.listarMedias = _context.CarregarMedias();
            ViewBag.listarClasses = _context.SP_ListarClasses();
            ViewBag.listarCampus = _context.SP_ListarCampus();
            ViewBag.listarPeriodos = _context.SP_ListarPeriodos();

            if (candidatura.ProvinciaID != -1)
                ViewBag.listarMunicipiosPorProvincia = _context.SP_ListarMunicipiosPorProvincia(candidatura.ProvinciaID);

            if (candidatura.AreaFormacaoID != -1)
                ViewBag.listarCursosMediosPorArea = _context.SP_ListarCursosMediosPorArea(candidatura.AreaFormacaoID);

            if (candidatura.CampusID != -1)
                ViewBag.listarFaculdades = _context.SP_ListarFaculdadesPorCampus(candidatura.CampusID);

            if (candidatura.FaculdadeID != -1)
                ViewBag.listarCursos = _context.SP_ListarCursosPorFaculdade(candidatura.FaculdadeID);
        }

        public ActionResult Recibo()
        {
            if(TempData["documento"] == null) return RedirectToAction("index");

            var resultado = _context.SP_Candidatura_Recibo(TempData["documento"]?.ToString());

            if (resultado == null) return RedirectToAction("index");

            ViewBag.recibo = resultado;

            return View();
        }
    }
}
