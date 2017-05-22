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

        [Range(1, double.MaxValue, ErrorMessage = "Debe seleccionar un Alumno")]
        public int? Alumno_id { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Debe seleccionar un Curso")]
        public int? Curso_id { get; set; }

        [StringLength(50)]
        public string Nota { get; set; }

        public virtual Alumno Alumno { get; set; }

        public virtual Curso Curso { get; set; }

    }
}
