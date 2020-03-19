﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudEscuela.Models
{
    public class Estudiante
    {
        public int id { get; set; }

        public string Matricula { get; set; }
        [Required]

        public string Nombre { get; set; }
        [Required]

        public string Apellido { get; set; }
        [Required]

        public string Sexo { get; set; }
        [Required]

        public string Materia { get; set; }
        [Required]

        public string Tutor { get; set; }

    }
}
