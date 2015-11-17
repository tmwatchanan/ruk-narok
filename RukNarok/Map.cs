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
        private Image background;
        private Location[] warp;
        public List<Monster> monsterList;

        internal Image Background
        {
            get;
            set;
        }

        public Map(int stage)
        {
            warp = new Location[2];
            monsterList = new List<Monster>();
            MapInit(stage);
        }

        public void MapInit(int stage)
        {
            switch (stage)
            {
                case 0:
                    {
                        Background = Properties.Resources.GrassBG;
                        break;
                    }
                case 1:
                    {
                        Background = Properties.Resources.Map1;
                        break;
                    }
                case 2:
                    {
                        Background = Properties.Resources.grass;
                        break;
                    }
                default:
                    {
                        Background = Properties.Resources.GrassBG;
                        break;
                    }
            }
        }
    }
}
