using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeliUsaid.Models
{
    public class Roles
    {
        [Key]
        public int IdRol { get; set; }
        public string Rol { get; set; }
        public string Descripcion { get; set; }

        public virtual List<Usuarios> Usuarios { get; set; }
    }
}