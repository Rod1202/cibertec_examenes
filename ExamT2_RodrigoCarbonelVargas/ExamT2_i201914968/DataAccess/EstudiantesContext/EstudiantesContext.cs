using Microsoft.EntityFrameworkCore;

namespace ExamT2_i201914968.DataAccess.EstudiantesContext
{
    public class EstudiantesContext : DbContext
    {

        public DbSet<EstudiantesEntity> Estudiantes { get; set; }
        public DbSet<NotasEntity> Notas { get; set; }
        public EstudiantesContext(DbContextOptions<EstudiantesContext> options) : base(options)
        {

        }
   

        public int SaveChange()
        {
            return base.SaveChanges();
        }
    }
}
