using Microsoft.EntityFrameworkCore;

namespace PROJ_UNIVERSIDADE.Models
{
    [Keyless]
    public class PreInscrito
    {
        public int CandidaturaID { get; set; }

        public string NomeCompleto { get; set; } = string.Empty;

        public string Telefone { get; set; } = string.Empty;
    }
}
