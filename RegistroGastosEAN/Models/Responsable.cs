using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistroGastosEAN.Models
{
    public class Responsable
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Numero Identificación")]
        public string NumeroIdentificacion { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
    }
}