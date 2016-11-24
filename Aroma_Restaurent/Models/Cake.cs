namespace Aroma_Restaurent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cake
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Items { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Price { get; set; }
    }
}
