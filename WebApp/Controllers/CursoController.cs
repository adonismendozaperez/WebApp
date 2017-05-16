using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo;

namespace WebApp.Controllers
{
    public class CursoController : Controller
    {
        private Curso cursos = new Curso();
        private AlumnoCurso alumnoCurso = new AlumnoCurso();

        // GET: Curso
        public ActionResult Index()
        {
            return View(cursos.Listar());
        }

        public ActionResult ver(int id)
        {
            return View(cursos.obtener(id));
        }

        public ActionResult Crud(int id = 0)
        {
            return View(
                id == 0 ? new Curso()
                : cursos.obtener(id));
        }
        public ActionResult Guardar(Curso model)
        {

            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/curso");
            }
            else
            {
                return View("~/views/curso/crud.cshtml", model);
            }
        }
        public ActionResult Eliminar(int id)
        {
            cursos.id = id;
            cursos.Eliminar();
            return Redirect("~/curso");
        }
    }
}