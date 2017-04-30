namespace LevelGraph
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LevelHistoryDBContext : DbContext
    {
        public LevelHistoryDBContext()
            : base("name=LevelHistoryDBContext")
        {
        }

        public virtual DbSet<Models.LevelHistory> LevelHistories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
