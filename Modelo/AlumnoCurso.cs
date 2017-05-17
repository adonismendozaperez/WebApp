namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("AlumnoCurso")]
    public partial class AlumnoCurso
    {
        public int id { get; set; }

        public int? Alumno_id { get; set; }

        public int? Curso_id { get; set; }

        [StringLength(50)]
        public string Nota { get; set; }

        public virtual Alumno Alumno { get; set; }

        public virtual Curso Curso { get; set; }

        #region Metodo de listar cursos que tiene un alumno
        public List<AlumnoCurso> Listar()
        {
            var AlumnoCursos = new List<AlumnoCurso>();
            try
            {
                using (var ctx = new TestContex())
                {
                    AlumnoCursos = ctx.AlumnoCurso.ToList();

                }
            }
            catch (Exception)
            {

                throw;
            }
            return AlumnoCursos;
        }
        #endregion

        #region Obtener alumnocursos
        public AlumnoCurso obtener(int id)
        {
            var alumnocursos = new AlumnoCurso();
            try
            {
                using (var ctx = new TestContex())
                {
                    alumnocursos = ctx.AlumnoCurso
                        .Where(x => x.id == id)
                        .SingleOrDefault();
                }


            }
            catch (Exception)
            {

                throw;
            }
            return alumnocursos;
        }
        #endregion

        #region Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new TestContex())
                {
                    if (this.id > 0)
                    {
                        db.Entry(this).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = System.Data.Entity.EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Eliminar
        public void Eliminar()
        {
            try
            {
                using (var ctx = new TestContex())
                {
                    ctx.Entry(this).State = System.Data.Entity.EntityState.Deleted;
                    ctx.SaveChanges();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

    }
}
