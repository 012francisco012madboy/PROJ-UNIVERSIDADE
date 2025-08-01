using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PROJ_UNIVERSIDADE.Models
{
    [Keyless]
    public class PagamentoMatricula
    {
        [Required(ErrorMessage = "Banco obrigatório")]
        public int BancoID { get; set; }

        [Required(ErrorMessage = "Candidatura obrigatória")]
        public int InscritoID { get; set; }

        [Required(ErrorMessage = "Data obrigatória")]
        public DateTime DataPagamento { get; set; }

        [Required(ErrorMessage = "Hora obrigatória")]
        public TimeSpan HoraPagamento { get; set; }

        [Required(ErrorMessage = "Recibo obrigatório")]
        public string? NumeroRecibo { get; set; }

        [Required(ErrorMessage = "Tipo de pagamento obrigatório")]
        public int TipoPagamentoID { get; set; }

        [Required(ErrorMessage = "Valor obrigatório")]
        //[Range(0.01, 9999999.99, ErrorMessage = "Valor inválido")]
        public decimal Valor { get; set; }
    }
}
