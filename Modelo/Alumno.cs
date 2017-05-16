namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Alumno")]
    public partial class Alumno
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Alumno()
        {
            Adjunto = new HashSet<Adjunto>();
            AlumnoCurso = new HashSet<AlumnoCurso>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellidos { get; set; }

        [Required]
        [StringLength(10)]
        public string Sexo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaNacimiento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Adjunto> Adjunto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlumnoCurso> AlumnoCurso { get; set; }
        
        #region Metodo de listar alumno
        public List<Alumno> Listar()
        {
            var alumnos = new List<Alumno>();
            try
            {
                using (var ctx = new TestContex())
                {
                    alumnos = ctx.Alumno.ToList();

                }


            }
            catch (Exception)
            {

                throw;
            }
            return alumnos;
        }
        #endregion

        #region Obtener alumno
        public Alumno obtener(int id)
        {
            var alumnos = new Alumno();
            try
            {
                using (var ctx = new TestContex())
                {
                    alumnos = ctx.Alumno.Include("AlumnoCurso")
                        .Include("AlumnoCurso.Curso")
                        .Where(x => x.id == id)
                        .SingleOrDefault();

                }


            }
            catch (Exception)
            {

                throw;
            }
            return alumnos;
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
