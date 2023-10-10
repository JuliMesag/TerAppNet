using Microsoft.EntityFrameworkCore;

namespace TerAppNet.Models
{
    public class MyDbContext: DbContext
    {
        public DbSet<PacienteModel> Pacientes { get; set;}

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        
        }
    }
}
