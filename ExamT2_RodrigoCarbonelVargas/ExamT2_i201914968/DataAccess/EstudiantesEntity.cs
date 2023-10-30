using System;

namespace ExamT2_i201914968.DataAccess
{
    public class EstudiantesEntity : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DNI { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Contact { get; set; }
        public string ContactNumber { get; set; }
    }
}
