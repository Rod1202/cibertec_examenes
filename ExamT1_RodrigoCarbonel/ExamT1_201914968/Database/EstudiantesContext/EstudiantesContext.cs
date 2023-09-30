using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ExamT1_201914968.Database.EstudiantesContext
{
    public class EstudiantesContext : DbContext
    {
        public DbSet<EstudiantesEntity>Estudiantes { get; set; }
        public EstudiantesContext(DbContextOptions<EstudiantesContext>options): base(options)
        {

        }

        public int SaveChange()
        {
            return base.SaveChanges();
        }

    }
}
