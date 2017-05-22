using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;

namespace WebApp.Helpers
{
    public class CombosHelpers: IDisposable
    {
        private static TestContex db = new TestContex();

        #region GetCursos
        public static List<Curso> GetCursos()
        {
            var curso = db.Curso.ToList();
            curso.Add(new Curso
            {
                id = 0,
                Nombre = "[Seleccione un curso........]"
            });
            return curso.OrderBy(x => x.Nombre).ToList();
        } 
        #endregion

        #region GetAlumnos
        public static List<Alumno> GetAlumnos()
        {
            var alumnos = db.Alumno.ToList();
            alumnos.Add(new Alumno
            {
                id = 0,
                Nombre = "[Seleccione un Alumno........]"
            });
            return alumnos.OrderBy(x => x.Nombre).ToList();
        }


        #endregion

        public void Dispose()
        {
           db.Dispose();
        }

    }
}