using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExamT2_i201914968.Models
{
    public class NotasViewModel
    {
        [DisplayName("Codigo de ALumno")]
        public int Id { get; set; }
        [DisplayName("Nombre del Curso")]
        public string Curso { get; set; }
        [DisplayName("Nota del curso")]
        [Required(ErrorMessage = "El campo Nota es requerido.")]
        [Range(0, 20, ErrorMessage = "La Nota debe estar entre 0 y 20.")]
        public int Nota { get; set; }
    }
}
