namespace PROJ_UNIVERSIDADE.Models
{
    public class ConsultaSemIdentificacao
    {
        public int CampusID { get; set; } = -1;

        public int CursoID { get; set; } = -1;

        public int PeriodoID { get; set; } = -1;

        public int AnoLetivo { get; set; } = -1;

        public DateTime dataInicio { get; set; }

        public DateTime dataFim { get; set; }
    }
}
