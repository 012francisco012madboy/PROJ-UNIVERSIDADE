using Microsoft.EntityFrameworkCore;

namespace PROJ_UNIVERSIDADE.Models
{
    [Keyless]
    public class Inscrito
    {
        public int InscritoID { get; set; }

        public string NomeCompleto { get; set; } = string.Empty;

        public string Telefone { get; set; } = string.Empty;
    }
}
