using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeliUsaid.Models
{
    public class Locales
    {
        [Key]
        public int IdLocal { get; set; }
        [Display(Name = "Razon Social")]
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo de la empresa")]
        public string Correo { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Logo { get; set; }

        //public virtual List<TblPlatos> Platos { get; set; }

        public int IdUsuario { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}