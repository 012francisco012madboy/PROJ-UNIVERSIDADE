using Microsoft.EntityFrameworkCore;

namespace PROJ_UNIVERSIDADE.Models
{
    [Keyless]
    public class MatriculaRecibo
    {
        public int MatriculaID { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Curso { get; set; } = string.Empty;
        public string Periodo { get; set; } = string.Empty;
        public int AnoInicio { get; set; }
        public int AnoFim { get; set; }
        public decimal Valor { get; set; }
    }
}
