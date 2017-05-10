using System;
using System.Text;
using Grabacr07.KanColleWrapper;
using Grabacr07.KanColleWrapper.Models;
using System.Data.Entity;

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
                insertLevel(fleet.Value);
            }
            //MemberTable<Ship> ships = KanColleClient.Current.Homeport.Organization.Ships;
            //KanmusuDbUtil.insertKanmusuLevel(ships);
        }

        public static void insertKanmusuLevel(MemberTable<Ship> ships)
        {
            if (0 != ships.Count)
            {
                insertLevel(ships);
            }
        }

        public static void insertLevel(Fleet fleet)
        {
            using (LevelLogDBContext context = new LevelLogDBContext())
            {
                Models.LevelLog levelLog;
                foreach (Ship ship in fleet.Ships)
                {
                    if (ship.IsLocked)
                    {
                        levelLog = context.LevelLogs.Find(ship.Id, DateTime.Now.Date);
                        //.SqlQuery<Models.LevelLog>("SELECT * FROM LevelLog WHERE Id = {0} AND InsertDate = {1}",
                        //ship.Id, DateTime.Now.ToString("yyyy/MM/dd")).FirstAsync().Result;
                        if (null == levelLog)
                        {
                            levelLog = new Models.LevelLog();
                            levelLog.Id = ship.Id;
                            levelLog.ShipId = ship.Info.Id;
                            levelLog.InsertDate = DateTime.Now.Date;
                            levelLog.Level = ship.Level;
                            context.LevelLogs.Add(levelLog);
                        }  else
                        {
                            levelLog.Level = ship.Level;
                            levelLog.ShipId = ship.Info.Id;
                        } 
                    }
                }
                context.SaveChanges();
            }
        }

        public static void insertLevel(MemberTable<Ship> ships)
        {
            using (LevelLogDBContext context = new LevelLogDBContext())
            {
                Models.LevelLog levelLog;
                foreach (Ship ship in ships.Values)
                {
                    if (ship.IsLocked)
                    {
                        levelLog = context.LevelLogs.Find(ship.Id, DateTime.Now.Date);
                        //.SqlQuery<Models.LevelLog>("SELECT * FROM LevelLog WHERE Id = {0} AND InsertDate = {1}",
                        //ship.Id, DateTime.Now.ToString("yyyy/MM/dd")).FirstAsync().Result;
                        if (null == levelLog)
                        {
                            levelLog = new Models.LevelLog();
                            levelLog.Id = ship.Id;
                            levelLog.ShipId = ship.Info.Id;
                            levelLog.InsertDate = DateTime.Now.Date;
                            levelLog.Level = ship.Level;
                            context.LevelLogs.Add(levelLog);
                        }
                        else
                        {
                            levelLog.Level = ship.Level;
                            levelLog.ShipId = ship.Info.Id;
                        }
                    }
                }
                context.SaveChanges();
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
