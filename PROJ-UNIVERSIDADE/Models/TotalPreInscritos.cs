using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROJ_UNIVERSIDADE.Models
{

    [Keyless]
    public class TotalPreInscritos
    {
        public int Total { get; set; }
    }
}
