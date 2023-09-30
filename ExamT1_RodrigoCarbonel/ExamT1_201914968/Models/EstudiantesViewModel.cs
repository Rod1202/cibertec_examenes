﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExamT1_201914968.Models
{
    public class EstudiantesListViewModel
    {
        public List<EstudiantesViewModel> List { get; set; }
        public EstudiantesListViewModel()
        {
            List = new List<EstudiantesViewModel>();
        }
    }
    public class EstudiantesViewModel
    {
        [DisplayName("Codigo")]
        public int Id { get; set; }
        [DisplayName("Nombre")]
        public string Name { get; set; }
        [DisplayName("Apellidos")]
        public string LastName { get; set; }
        [DisplayName("DNI")]
        public string DNI { get; set; }
        [DisplayName("FechaNacimiento")]
        public DateTime BirthDate { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Telefono")]
        public string Phone { get; set; }
        [DisplayName("Contacto")]
        public string Contact { get; set; }
        [DisplayName("Telefono Contacto")]
        public string ContactNumber { get; set; }

    }
}
