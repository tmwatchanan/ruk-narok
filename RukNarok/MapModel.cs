using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;

namespace RukNarok
{
    class MapModel : Model
    {
        private List<Map> mapList;
        private int currentMap;
        private Map zero = new Map(0);
        private Map one = new Map(1);
        private Map two = new Map(2);

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
            MapList.Add(zero);
            MapList.Add(one);
            MapList.Add(two);
            Update();
        }

        public void Update()
        {
            NotifyAll();
        }
    }
}
