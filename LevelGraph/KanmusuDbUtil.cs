using System;
using System.Text;
using Grabacr07.KanColleWrapper;
using Grabacr07.KanColleWrapper.Models;

namespace LevelGraph
{
    class KanmusuDbUtil : DbUtil
    {
        public static void insertKanmusuLevel(MemberTable<Ship> ships)
        {
            if (0 != ships.Count)
            {
                insertLevel(ships);
                insertKanmusu(ships);
            }
        }

        public static void insertLevel(MemberTable<Ship> ships)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            StringBuilder sqlBuilder = new StringBuilder("INSERT INTO Level VALUES ");
            StringBuilder builder = new StringBuilder();
            foreach (Ship ship in ships.Values)
            {
                if (!builder.ToString().Equals(""))
                {
                    builder.Append(", ");
                }
                builder.Append("(");
                builder.Append(ship.Info.Id);
                builder.Append(", ");
                builder.Append(ship.Level);
                builder.Append(", ");
                builder.Append(date);
                builder.Append(")");
            }
            insert(builder.ToString());
        }

        private static void insertKanmusu(MemberTable<Ship> ships)
        {
            StringBuilder sqlBuilder = new StringBuilder("INSERT INTO Kanmusu VALUES ");
            StringBuilder builder = new StringBuilder();
            foreach (Ship ship in ships.Values)
            {
                if (!builder.ToString().Equals(""))
                {
                    builder.Append(", ");
                }
                builder.Append("(");
                builder.Append(ship.Info.Id);
                builder.Append(", ");
                builder.Append(ship.Info.Name);
                builder.Append(")");
            }
            insert(builder.ToString());
        }

        public static void selectKanmusuLevel()
        {

        }

        public static void selectLevel()
        {

        }

        public static void selectKanmusu()
        {
            
        }

        public static void updateKanmusuLevel()
        {
            // TODO iranai
        }

        public static void updateLevel()
        {
        }

        private static void updateKanmusu()
        {
            // todo iranai
        }

        public static void createKanmusuLevelTable()
        {
        }

        private static void createLevelTable()
        {
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
