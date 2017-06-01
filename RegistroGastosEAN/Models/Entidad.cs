using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistroGastosEAN.Models
{
    public class Entidad
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Numero ID Fiscal")]
        public string IdentificadorFiscal { get; set; }

        [Required]
        [Display(Name = "Entidad")]
        public string RazonSocial { get; set; }
    }
}