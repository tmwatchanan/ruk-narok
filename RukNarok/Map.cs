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
        internal Location[] Warp
        {
            get;
            set;
        } = new Location[2];
        internal int Stage
        {
            get;
            set;
        }

        public Map(int stage)
        {
            Warp[0] = new Location(0, 300);
            Warp[1] = new Location(800, 300);
            monsterList = new List<Monster>();
            MainBG = null;
            BattleBG = null;
            Stage = stage;
        }
    }
}
