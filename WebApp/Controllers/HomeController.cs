using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private Alumno alumno = new Alumno();
        private AlumnoCurso alumnoCurso = new AlumnoCurso();
        // GET: Home
        public ActionResult Index()
        {         
            return View(alumno.Listar());
        }
        public ActionResult ver(int id)
        {
            return View(alumno.obtener(id));
        }

        public ActionResult Crud( int id = 0)
        {
            return View(
                id==0? new Alumno()
                :alumno.obtener(id));
        }



        public ActionResult Guardar(Alumno model)
        {
            
            if (ModelState.IsValid)
            {
               model.Guardar();
                return Redirect("~/home");
            }
            else
            {
                return View("~/views/home/crud.cshtml",model);
            }
        }
        public ActionResult Eliminar(int id)
        {
            alumno.id = id;
            alumno.Eliminar();
            return Redirect("~/home");
        }

    }
}