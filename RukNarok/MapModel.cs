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

        private int monsterCount;
        internal int MonsterCount
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
                switch (i)
                {
                    case 0:
                        addMap.monsterList.Add(BabyDesertWolf());
                        addMap.monsterList.Add(KingYamu());
                        break;
                    default:
                        break;
                }
                MonsterCount = addMap.monsterList.Count;
                MapList.Add(addMap);
            }
            Update();
        }

        public void Update()
        {
            NotifyAll();
        }

        private Monster BabyDesertWolf()
        {
            Monster babyDesertWolf = new Monster();
            babyDesertWolf.AttackDamage = 1;
            babyDesertWolf.EXP = 10;
            babyDesertWolf.MaxHP = babyDesertWolf.HP = 50;
            babyDesertWolf.Name = "BabyDesertWolf";
            return babyDesertWolf;
        }

        private Monster KingYamu()
        {
            Monster kingYamu = new Monster();
            kingYamu.AttackDamage = 2;
            kingYamu.EXP = 20;
            kingYamu.MaxHP = kingYamu.HP = 100;
            kingYamu.Name = "KingYamu";
            return kingYamu;
        }
    }
}
