using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PROJ_UNIVERSIDADE.Models
{
    [Keyless]
    public class ConsultaFinancaServico
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public int BancoID { get; set; } = -1;

        [Required(ErrorMessage = "Campo obrigatório")]
        public int TipoPagamentoID { get; set; } = -1;

        [Required(ErrorMessage = "Campo obrigatório")]
        public int TipoServico { get; set; } = -1;
    }
}
