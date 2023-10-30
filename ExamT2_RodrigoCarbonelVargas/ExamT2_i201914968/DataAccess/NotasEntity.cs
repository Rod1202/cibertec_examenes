using System.ComponentModel.DataAnnotations;

namespace ExamT2_i201914968.DataAccess
{
    public class NotasEntity : BaseEntity
    {

        [Required]
        public string Curso { get; set; }

        [Required]
        public int Nota { get; set; }

        public int EstudianteId { get; set; }

        public EstudiantesEntity Estudiante { get; set; }
    }
}
