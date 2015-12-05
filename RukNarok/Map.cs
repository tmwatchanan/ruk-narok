using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;

namespace RukNarok
{
    class Map
    {
        private Image mainBG;
        private Image battleBG;
        private Location[] warp;
        public List<Monster> monsterList;
        private int stage;

        internal Image MainBG
        {
            get;
            set;
        }
        internal Image BattleBG
        {
            get;
            set;
        }
        internal int Stage
        {
            get;
            set;
        }

        public Map(int stage)
        {
            warp = new Location[2];
            monsterList = new List<Monster>();
            Stage = stage;
        }
    }
}
