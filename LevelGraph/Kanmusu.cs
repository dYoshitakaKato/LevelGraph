using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelGraph
{
    class Kanmusu
    {
        private int _id;
        private int _level;
        private String _name;
        private List<int> _levels;

        public Kanmusu(int id, int level, String name) : this(id, level, name, new List<int>(level))
        {
        }

        public Kanmusu(int id, int level, String name, List<int> levels)
        {
            Id = id;
            Level = level;
            Name = name;
            Levels = levels;
        }

        public List<int> Levels
        {
            get
            {
                return _levels;
            }

            private set
            {
                _levels = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            private set
            {
                _name = value;
            }
        }

        public int Id
        {
            get
            {
                return _id;
            }

            private set
            {
                _id = value;
            }
        }

        public int Level
        {
            get
            {
                return _level;
            }

            private set
            {
                _level = value;
            }
        }
    }
}
