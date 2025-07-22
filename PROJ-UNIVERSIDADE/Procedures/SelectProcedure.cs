using Microsoft.EntityFrameworkCore;
using PROJ_UNIVERSIDADE.Models;

namespace PROJ_UNIVERSIDADE.Contexts
{
    public class SelectProcedure(DbContextOptions<SelectProcedure> options) : DbContext(options)
    {
        public DbSet<Campus> tb_campus { get; set; }

        public List<Campus> SP_ListarCampi()
        {
            return [.. tb_campus.FromSqlRaw("EXEC SP_ListarCampi")];
        }
    }
}
