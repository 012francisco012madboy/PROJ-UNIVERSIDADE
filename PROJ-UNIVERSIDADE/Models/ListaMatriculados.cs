using Microsoft.EntityFrameworkCore;

namespace PROJ_UNIVERSIDADE.Models
{
    [Keyless]
    public class ListaMatriculados
    {
        public int InscritoID { get; set; }
        
        public int MatriculaID { get; set; }

        public string NomeCompleto { get; set; } = string.Empty;

        public string Telefone { get; set; } = string.Empty;
    }
}
