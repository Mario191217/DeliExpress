using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeliUsaid.Models
{
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        public int IdPersona { get; set; }
        public virtual Personas Personas { get; set; }
        public string Usuario { get; set; }
        //[DataType(DataType.Password)]
        public string Clave { get; set; }
        public int IdRol { get; set; }
        public virtual Roles Roles { get; set; }

    }
}