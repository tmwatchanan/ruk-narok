using System.Collections.Generic;
using System.Drawing;

namespace RukNarok
{

    class MapModel : Model
    {
        private const int maxMap = 1;

        private List<Map> mapList;
        private int currentMap;

        public const int WarpLeft = 0;
        public const int WarpRight = 1;

        internal List<Map> MapList
        {
            get;
            set;
        }
        internal int CurrentMap
        {
            get;
            set;
        }

        public MapModel()
        {
            CurrentMap = 0;
            MapList = new List<Map>();
            for (int i = 0; i < maxMap; ++i)
            {
                Map addMap = new Map(i);
                object objMainBG = Properties.Resources.ResourceManager.GetObject("MainBG" + i);
                addMap.MainBG = (Image)objMainBG;
                object objBattleBG = Properties.Resources.ResourceManager.GetObject("BattleBG" + i);
                addMap.BattleBG = (Image)objBattleBG;
                MapList.Add(addMap);
            }
            Update();
        }

        public void Update()
        {
            NotifyAll();
        }
    }
}
