using System;
using System.Collections.Generic;
using System.Drawing;

namespace RukNarok
{
    class MapModel : Model
    {
        public const int MaxMap = 3;

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
            Map addMap;
            for (int i = 0; i < MaxMap; ++i)
            {
                addMap = new Map(i);
                object objMainBG = Properties.Resources.ResourceManager.GetObject("MainBG" + Convert.ToString(i));
                addMap.MainBG = (Image)objMainBG;
                objMainBG = null;
                object objBattleBG = Properties.Resources.ResourceManager.GetObject("BattleBG" + Convert.ToString(i));
                addMap.BattleBG = (Image)objBattleBG;
                objBattleBG = null;
                switch (i)
                {
                    case 0:
                        addMap.monsterList.Add(BabyDesertWolf());
                        addMap.monsterList.Add(KingYamu());
                        break;
                    case 1:
                        addMap.monsterList.Add(Alligator());
                        break;
                    case 2:

                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    default:
                        break;
                }
                MapList.Add(addMap);
                addMap = null;
            }
            Update();
        }

        public void Update()
        {
            NotifyAll();
        }

        private Monster BabyDesertWolf()
        {
            Monster monster = new Monster();
            monster.AttackDamage = 1;
            monster.EXP = 10;
            monster.MaxHP = monster.HP = 50;
            monster.Name = "BabyDesertWolf";
            monster.Death = false;
            return monster;
        }

        private Monster KingYamu()
        {
            Monster monster = new Monster();
            monster.AttackDamage = 2;
            monster.EXP = 20;
            monster.MaxHP = monster.HP = 100;
            monster.Name = "KingYamu";
            monster.Death = false;
            return monster;
        }

        private Monster Alligator()
        {
            Monster monster = new Monster();
            monster.AttackDamage = 2;
            monster.EXP = 20;
            monster.MaxHP = monster.HP = 100;
            monster.Name = "Alligator";
            monster.Death = false;
            return monster;
        }


    }
}
