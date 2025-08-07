using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PROJ_UNIVERSIDADE.Models
{
    [Keyless]
    public class ConfirmarInscicao
    {
        [Required(ErrorMessage = "Candidatura obrigatória")]
        public int CandidaturaID { get; set; }
    }
}
