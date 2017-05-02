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
            Models.LevelLog levelLog;
            using (LevelLogDBContext context = new LevelLogDBContext())
            {
                foreach (Fleet fleet in fleets.Values)
                {
                    foreach (Ship ship in fleet.Ships)
                    {
                        if (ship.IsLocked)
                        {
                            levelLog = new Models.LevelLog();
                            levelLog.Id = ship.Id;
                            levelLog.ShipId = ship.Info.Id;
                            levelLog.InsertDate = DateTime.Now;
                            levelLog.Level = ship.Level;
                            var result = context.Database.SqlQuery<int>("SELECT ShipId, InsertDate, Level FROM LEVELHISTORY WHERE ShipId = {0} AND InsertDate = {1}",
                                levelLog.ShipId, levelLog.InsertDate.ToString("yyyy/MM/dd")).CountAsync().Result;
                            if (result < 1)
                            {
                                context.LevelLogs.Add(levelLog);
                            } else
                            {
                                //TODO update
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
            using (LevelLogDBContext context = new LevelLogDBContext())
            {
                context.LevelLogs.Create();
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
