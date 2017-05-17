using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modelo;

namespace WebApp.Controllers
{
    public class AlumnoCursoesController : Controller
    {
        private TestContex db = new TestContex();

        // GET: AlumnoCursoes
        public ActionResult Index()
        {
            var alumnoCurso = db.AlumnoCurso.Include(a => a.Alumno).Include(a => a.Curso);
            return View(alumnoCurso.ToList());
        }

        // GET: AlumnoCursoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlumnoCurso alumnoCurso = db.AlumnoCurso.Find(id);
            if (alumnoCurso == null)
            {
                return HttpNotFound();
            }
            return View(alumnoCurso);
        }

        // GET: AlumnoCursoes/Create
        public ActionResult Create()
        {
            ViewBag.Alumno_id = new SelectList(db.Alumno, "id", "Nombre");
            ViewBag.Curso_id = new SelectList(db.Curso, "id", "Nombre");
            return View();
        }

        // POST: AlumnoCursoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Alumno_id,Curso_id,Nota")] AlumnoCurso alumnoCurso)
        {
            if (ModelState.IsValid)
            {
                db.AlumnoCurso.Add(alumnoCurso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Alumno_id = new SelectList(db.Alumno, "id", "Nombre", alumnoCurso.Alumno_id);
            ViewBag.Curso_id = new SelectList(db.Curso, "id", "Nombre", alumnoCurso.Curso_id);
            return View(alumnoCurso);
        }

        // GET: AlumnoCursoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlumnoCurso alumnoCurso = db.AlumnoCurso.Find(id);
            if (alumnoCurso == null)
            {
                return HttpNotFound();
            }
            ViewBag.Alumno_id = new SelectList(db.Alumno, "id", "Nombre", alumnoCurso.Alumno_id);
            ViewBag.Curso_id = new SelectList(db.Curso, "id", "Nombre", alumnoCurso.Curso_id);
            return View(alumnoCurso);
        }

        // POST: AlumnoCursoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Alumno_id,Curso_id,Nota")] AlumnoCurso alumnoCurso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumnoCurso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Alumno_id = new SelectList(db.Alumno, "id", "Nombre", alumnoCurso.Alumno_id);
            ViewBag.Curso_id = new SelectList(db.Curso, "id", "Nombre", alumnoCurso.Curso_id);
            return View(alumnoCurso);
        }

        // GET: AlumnoCursoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlumnoCurso alumnoCurso = db.AlumnoCurso.Find(id);
            if (alumnoCurso == null)
            {
                return HttpNotFound();
            }
            db.AlumnoCurso.Remove(alumnoCurso);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
