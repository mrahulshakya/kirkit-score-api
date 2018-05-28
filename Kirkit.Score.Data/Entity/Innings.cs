using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Kirkit.Score.Data.Enitity
{
    public class Innings : IEntityModel
    {
        public Innings()
        {
            BallUpdate = new HashSet<BallUpdate>();
        }
        public int PkInnings { get; set; }
        public int FkBattingTeam { get; set; }
        public int FkBallingTeam { get; set; }
        public int FkStrikePlayer { get; set; }
        public int FkNonStrikePlayer { get; set; }
        public int FkBaller { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }

        public Team FkBattingTeamNavigation { get; set; }
        public Team FkBallingTeamNavigation { get; set; }
        public Player FkPlayerNavigation { get; set; }
        public Player FkStrikePlayerNavigation { get; set; }
        public Player FkNonStrikePLayerNavigation { get; set; }
        public Player FkBallerNavigation { get; set; }
        public ICollection<BallUpdate> BallUpdate { get; set; }


        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Innings>(entity =>
            {
                entity.HasKey(e => e.PkInnings);
                entity.Property(e => e.DtCreated).HasColumnType("datetime");
                entity.Property(e => e.DtUpdated).HasColumnType("datetime");
            });
        }
    }
}
