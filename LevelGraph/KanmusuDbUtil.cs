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

        public static void insertKanmusuLevel()
        {
            foreach (var fleet in KanColleClient.Current.Homeport.Organization.Fleets)
            {
                insertKanmusuLevel(fleet.Value);
            }
        }

        public static void insertKanmusuLevel(Fleet fleet)
        {
            if (0 != fleet.Ships.Length)
            {
                insertLevel(fleet);
            }
        }

        public static void insertLevel(Fleet fleet)
        {
            foreach (Ship ship in fleet.Ships)
            {
                Models.LevelLog levelLog;
                using (LevelLogDBContext context = new LevelLogDBContext())
                {
                    if (ship.IsLocked)
                    {
                        levelLog = new Models.LevelLog();
                        Models.LevelLog result;
                        try
                        {
                            result = context.Database.SqlQuery<Models.LevelLog>("SELECT * FROM LevelLog WHERE Id = {0} AND InsertDate = {1}",
                            ship.Id, DateTime.Now.ToString("yyyy/MM/dd")).FirstAsync().Result;
                            result.Level = ship.Level;
                        }
                        catch (AggregateException e)
                        {
                            result = new Models.LevelLog();
                            levelLog.Id = ship.Id;
                            levelLog.ShipId = ship.Info.Id;
                            levelLog.InsertDate = DateTime.Now;
                            levelLog.Level = ship.Level;
                            context.LevelLogs.Add(levelLog);
                        }
                        context.SaveChanges();
                    }
                }
            }
        }

        public static void insertLevel(MemberTable<Fleet> fleets)
        {
            {
                foreach (Fleet fleet in fleets.Values)
                {
                    insertLevel(fleet);
                }
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
