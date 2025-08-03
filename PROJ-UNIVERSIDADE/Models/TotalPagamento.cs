using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PROJ_UNIVERSIDADE.Models
{
    [Keyless]
    public class TotalPagamento
    {
        public int TotalPagamentos { get; set; }

        public decimal TotalValor { get; set; }

        public DateTime DataPagamento { get; set; }
    }
}
