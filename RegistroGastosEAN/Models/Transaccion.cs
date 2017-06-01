using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistroGastosEAN.Models
{
    public class Transaccion
    {
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/mmm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [Required]
        [Display(Name = "Monto")]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0,00", "999999999,00")]
        public decimal Monto { get; set; }

        [Required]
        [Display(Name = "Agente")]
        public int ResponsableID { get; set; }

        [Required]
        [Display(Name = "Entidad")]
        public int EntidadID { get; set; }

        [Display(Name = "Agentes")]
        public virtual Responsable Responsables { get; set; }

        [Display(Name = "Entidades")]
        public virtual Entidad Entidades { get; set; }

    }
}