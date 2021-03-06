namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Adjunto")]
    public partial class Adjunto
    {
        public int id { get; set; }

        public int? Alumno_id { get; set; }

        [StringLength(50)]
        public string archivo { get; set; }

        public virtual Alumno Alumno { get; set; }
    }
}
