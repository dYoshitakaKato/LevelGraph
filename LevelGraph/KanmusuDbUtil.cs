using System;
using System.Text;
using Grabacr07.KanColleWrapper;
using Grabacr07.KanColleWrapper.Models;

namespace LevelGraph
{
    class KanmusuDbUtil : DbUtil
    {
        public static void insertKanmusuLevel(MemberTable<Fleet> fleets)
        {
            if (0 != fleets.Count)
            {
                insertLevel(fleets);
            }
        }

        public static void insertLevel(MemberTable<Fleet> fleets)
        {
            Models.LevelHistory levelHistory;
            using (LevelHistoryDBContext context = new LevelHistoryDBContext())
            {
                var count = context.Database.SqlQuery<int>("SELECT MAX(SeqNum) FROM LEVELHISTORY; ").FirstAsync().Result;
                foreach (Fleet fleet in fleets.Values)
                {
                    foreach (Ship ship in fleet.Ships)
                    {
                        if (ship.IsLocked)
                        {
                            levelHistory = new Models.LevelHistory();
                            levelHistory.Id = ship.Id;
                            levelHistory.ShipId = ship.Info.Id;
                            levelHistory.InsertDate = DateTime.Now;
                            levelHistory.Level = ship.Level;
                            var test = context.Database.SqlQuery<int>("SELECT SeqNum FROM LEVELHISTORY WHERE Id = {0} AND InsertDate = {1}", 
                                levelHistory.Id, levelHistory.InsertDate.ToString("yyyy/MM/dd")).CountAsync().Result;
                            if (test < 1)
                            {
                                levelHistory.SeqNum = ++count;
                                context.LevelHistories.Add(levelHistory);
                            }
                        }
                    }
                }
                context.SaveChanges();
            }
        }

        public static void selectLevel()
        {

        }

        public static void updateLevel()
        {
        }

        public static void createKanmusuLevelTable()
        {
        }

        private static void createLevelTable()
        {
            using (LevelHistoryDBContext context = new LevelHistoryDBContext())
            {
                context.LevelHistories.Create();
                context.SaveChanges();
            }
        }

        private static void createKanmusuTable()
        {
        }

        public static Boolean checKanmusuLevelTable()
        {
            return false;
        }
    }
}
