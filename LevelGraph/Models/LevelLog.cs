namespace LevelGraph.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LevelLog")]
    public partial class LevelLog
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime InsertDate { get; set; }

        public int ShipId { get; set; }

        public int Level { get; set; }
    }
}
