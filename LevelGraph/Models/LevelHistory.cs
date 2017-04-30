namespace LevelGraph.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LevelHistory")]
    public partial class LevelHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SeqNum { get; set; }

        public int Id { get; set; }

        public int ShipId { get; set; }

        public int Level { get; set; }

        [Column(TypeName = "date")]
        public DateTime InsertDate { get; set; }
    }
}
