using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeliUsaid.Models
{
    public class Personas
    {
        [Key]
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdGenero { get; set; }
        public virtual Generos Generos { get; set; }
        public string DUI { get; set; }
        public string NIT { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public virtual List<Usuarios> Usuarios { get; set; }
    }
}