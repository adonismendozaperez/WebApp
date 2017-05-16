namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Curso")]
    public partial class Curso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Curso()
        {
            AlumnoCurso = new HashSet<AlumnoCurso>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlumnoCurso> AlumnoCurso { get; set; }


        #region Metodo de listar cursos
        public List<Curso> Listar()
        {
            var cursos = new List<Curso>();
            try
            {
                using (var ctx = new TestContex())
                {
                    cursos = ctx.Curso.ToList();

                }
            }
            catch (Exception)
            {

                throw;
            }
            return cursos;
        }
        #endregion

        #region Obtener Cursos
        public Curso obtener(int id)
        {
            var Cursos = new Curso();
            try
            {
                using (var ctx = new TestContex())
                {
                    Cursos = ctx.Curso.Include("AlumnoCurso")
                        .Include("AlumnoCurso.Alumno")
                        .Where(x => x.id == id)
                        .SingleOrDefault();

                }


            }
            catch (Exception)
            {

                throw;
            }
            return Cursos;
        }
        #endregion

        #region Metodo guardar y Editar
        public void Guardar()
        {

            try
            {
                using (var ctx = new TestContex())
                {
                    if (this.id > 0)
                    {
                        ctx.Entry(this).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        ctx.Entry(this).State = System.Data.Entity.EntityState.Added;
                    }

                    ctx.SaveChanges();
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
