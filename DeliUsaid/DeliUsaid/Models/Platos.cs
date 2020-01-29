using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeliUsaid.Models
{
    public class Platos
    {
        [Key]
        public int IdPlato { get; set; }
        [Display(Name = "Plato")]
        public string NombrePlato { get; set; }
        public double Precio { get; set; }
        public string Descripcion { get; set; }

        public string Foto1 { get; set; }
        public string Foto2 { get; set; }
        public string Foto3 { get; set; }

        public int IdLocal { get; set; }
        public virtual Locales Locales { get; set; }
    }
}