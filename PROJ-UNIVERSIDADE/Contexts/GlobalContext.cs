using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PROJ_UNIVERSIDADE.Models;
using Microsoft.AspNetCore.Mvc;
using PROJ_UNIVERSIDADE.Contexts;

namespace PROJ_UNIVERSIDADE.Contexts
{
    public class GlobalContext(DbContextOptions<GlobalContext> options) : DbContext(options)
    {
        //NACIONALIDADE
        public DbSet<Nacionalidade> tb_Nacionalidade { get; set; }

        public List<Nacionalidade> SP_ListarNacionalidades()
        {
            return tb_Nacionalidade.FromSqlRaw("EXEC SP_ListarNacionalidades").ToList();
        }

        //PROVINCIA
        public DbSet<Provincia> tb_Provincia { get; set; }

        public List<Provincia> SP_ListarProvincias()
        {
            return [.. tb_Provincia.FromSqlRaw("EXEC SP_ListarProvincias")];
        }

        //MUNICIPIO
        public DbSet<Municipio> tb_Municipio { get; set; }

        public List<Municipio> SP_ListarMunicipiosPorProvincia(int provincia)
        {
            var idProvincia = new SqlParameter("@ProvinciaID", provincia);
            return [.. tb_Municipio.FromSqlRaw("EXEC SP_ListarMunicipiosPorProvincia @ProvinciaID", idProvincia)];
        }

        //SEXO
        public DbSet<Sexo> tb_Sexo { get; set; }

        public List<Sexo> SP_ListarSexos()
        {
            return [.. tb_Sexo.FromSqlRaw("EXEC SP_ListarSexos")];
        }

        //ESTADO CIVIL
        public DbSet<EstadoCivil> tb_EstadoCivil { get; set; }

        public List<EstadoCivil> SP_ListarEstadosCivis()
        {
            return [.. tb_EstadoCivil.FromSqlRaw("EXEC SP_ListarEstadosCivis")];
        }

        //TIPO DOCUMENTO
        public DbSet<TipoDocumento> tb_TipoDocumento { get; set; }

        public List<TipoDocumento> SP_ListarTipoDocumentos()
        {
            return [.. tb_TipoDocumento.FromSqlRaw("EXEC SP_ListarTipoDocumentos")];
        }

        //CAMPUS
        public DbSet<Campus> tb_campus { get; set; }

        public List<Campus> SP_ListarCampus()
        {
            return [.. tb_campus.FromSqlRaw("EXEC SP_ListarCampus")];
        }

        //FACULDADE
        public DbSet<Faculdade> tb_Faculdade { get; set; }

        public List<Faculdade> SP_ListarFaculdadesPorCampus(int idCampus)
        {
            var campusId = new SqlParameter("@CampusID", idCampus);
            return [.. tb_Faculdade.FromSqlRaw("EXEC SP_ListarFaculdadesPorCampus @CampusID", campusId)];
        }

        //CURSO FACULDADE
        public DbSet<Curso> tb_Curso { get; set; }

        public List<Curso> SP_ListarCursosPorFaculdade(int idFaculdade)
        {
            var faculdadeId = new SqlParameter("@FaculdadeID", idFaculdade);
            return [.. tb_Curso.FromSqlRaw("EXEC SP_ListarCursosPorFaculdade @FaculdadeID", faculdadeId)];
        }

        //PERIODO
        public DbSet<Periodo> tb_Periodo { get; set; }

        public List<Periodo> SP_ListarPeriodos()
        {
            return [.. tb_Periodo.FromSqlRaw("EXEC SP_ListarPeriodos")];
        }

        //AREA FORMAÇÃO
        public DbSet<AreaFormacao> tb_AreaFormacao { get; set; }

        public List<AreaFormacao> SP_ListarAreasFormacao()
        {
            return [.. tb_AreaFormacao.FromSqlRaw("EXEC SP_ListarAreasFormacao")];
        }

        //CURSO MÉDIO
        public DbSet<CursoMedio> tb_CursoMedio { get; set; }

        public List<CursoMedio> SP_ListarCursosMediosPorArea(int idAreaFormacao)
        {
            var areaFormacaoId = new SqlParameter("@AreaFormacaoID", idAreaFormacao);
            return [.. tb_CursoMedio.FromSqlRaw("EXEC SP_ListarCursosMediosPorArea @AreaFormacaoID", areaFormacaoId)];
        }

        //ANO
        public List<int> CarregarUltimos10Anos()
        {
            int anoAtual = DateTime.Now.Year;
            List<int> anos = new List<int>();

            for (int i = 0; i <= 10; i++)
            {
                anos.Add(anoAtual - i);
            }

            return anos;
        }

        //ANO LETIVO
        public DbSet<AnoLetivo> tb_AnoLetivo { get; set; }

        public List<AnoLetivo> SP_ListarAnoLetivo()
        {
            return [.. tb_AnoLetivo.FromSqlRaw("EXEC SP_ListarAnoLetivo")];
        }

        //MÉDIA
        public List<int> CarregarMedias()
        {
            List<int> media = new List<int>();

            for (int i = 20; i >= 10; i--)
            {
                media.Add(i);
            }

            return media;
        }

        //CLASSE
        public DbSet<Classe> tb_Classe { get; set; }

        public List<Classe> SP_ListarClasses()
        {
            return tb_Classe.FromSqlRaw("EXEC SP_ListarClasses").ToList();
        }

        //TOTAL PRÉ INSCRITOS
        public DbSet<TotalPreInscritos> tb_CandidaturaSuperior { get; set; }

        public int SP_TotalPreInscritos()
        {
            var resultado = tb_CandidaturaSuperior
           .FromSqlRaw("EXEC SP_TotalPreInscritos")
           .AsEnumerable()
           .FirstOrDefault();

            return resultado?.Total ?? 0;
        }

        //PRÉ INSCRITO
        public DbSet<PreInscrito> tb_BuscarPreInscrito { get; set; }

        public PreInscrito? SP_BuscarPreInscrito(ConsultaComIdentificacao consulta)
        {
            var Tipo = new SqlParameter("@Tipo", consulta.Tipo);
            var Identificacao = new SqlParameter("@Identificacao", consulta.Identificacao);

            var resultado = tb_BuscarPreInscrito
            .FromSqlRaw("EXEC SP_BuscarPreInscrito @Tipo, @Identificacao", Tipo, Identificacao)
            .AsEnumerable()
            .FirstOrDefault();

            return resultado ?? null;
        }

        //LISTA INSCRITOS
        public DbSet<ListaInscritos> tb_ListarInscritos { get; set; }

        public List<ListaInscritos> SP_ListarInscritos(ConsultaSemIdentificacao consulta)
        {
            var CampusID = new SqlParameter("@CampusID", consulta.CampusID);
            var CursoID = new SqlParameter("@CursoID", consulta.CursoID);
            var PeriodoID = new SqlParameter("@PeriodoID", consulta.PeriodoID);
            var AnoLetivo = new SqlParameter("@AnoLetivo", consulta.AnoLetivo);

            return tb_ListarInscritos
            .FromSqlRaw("EXEC SP_ListarInscritos @CampusID, @CursoID, @PeriodoID, @AnoLetivo",
                CampusID, CursoID, PeriodoID, AnoLetivo)
            .ToList();
        }

        //TOTAL INSCRITOS
        public DbSet<TotalInscritos> tb_Inscrito { get; set; }

        public int SP_TotalInscritos()
        {
            var resultado = tb_Inscrito
           .FromSqlRaw("EXEC SP_TotalInscritos")
           .AsEnumerable()
           .FirstOrDefault();

            return resultado?.Total ?? 0;
        }

        //TOTAL MATRICULADOS
        public DbSet<TotalMatriculados> tb_Matricula { get; set; }

        public int SP_TotalMatriculados()
        {
            var resultado = tb_Matricula
           .FromSqlRaw("EXEC SP_TotalMatriculados")
           .AsEnumerable()
           .FirstOrDefault();

            return resultado?.Total ?? 0;
        }

        //TIPO PAGAMENTO
        public DbSet<TipoPagamento> tb_TipoPagamento { get; set; }

        public List<TipoPagamento> SP_ListarTiposPagamento()
        {
            return tb_TipoPagamento.FromSqlRaw("EXEC SP_ListarTiposPagamento").ToList();
        }

        //BANCOS    
        public DbSet<Banco> tb_Banco { get; set; }

        public List<Banco> SP_Listar_Bancos(int idTipoPagamento)
        {
            var tipoPagamentoId = new SqlParameter("@TipoPagamentoID", idTipoPagamento);
            return [.. tb_Banco.FromSqlRaw("EXEC SP_Listar_Bancos @TipoPagamentoID", tipoPagamentoId)];
        }
    }
}
