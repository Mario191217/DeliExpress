using DeliUsaid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeliUsaid.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        Contexto db = new Contexto();
        public ActionResult Index()
        {
            if(db.Roles.Count() == 0)
            {
                AddRol("Representante");
                AddRol("Consumidor");
            }
            if(db.Generos.Count() == 0)
            {
                AddGenero("Maculino");
                AddGenero("Femenino");
            }
            return View();
        }

        public void AddRol(string rol)
        {
            Roles roles = new Roles();
            roles.Rol = rol;
            roles.Descripcion = rol;
            db.Roles.Add(roles);
            db.SaveChanges();
        }

        public void AddGenero(string genero)
        {
            Generos generos = new Generos();
            generos.Genero = genero;
            db.Generos.Add(generos);
            db.SaveChanges();
        }

        public ActionResult Principal()
        {
            return View();
        }
    }
}