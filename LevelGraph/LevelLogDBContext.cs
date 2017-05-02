namespace LevelGraph
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LevelLogDBContext : DbContext
    {
        public LevelLogDBContext()
            : base("name=LevelLogDBContext")
        {
        }

        public virtual DbSet<Models.LevelLog> LevelLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
