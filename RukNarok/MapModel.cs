using System;
using System.Collections.Generic;
using System.Drawing;

namespace RukNarok
{
    class MapModel : Model
    {
        public const int MaxMap = 5;

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

        public void Update()
        {
            NotifyAll();
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
                        addMap.monsterList.Add(LeafCat());
                        addMap.monsterList.Add(KingYamu());
                        addMap.monsterList.Add(Chonchon());
                        break;
                    case 1:
                        addMap.monsterList.Add(Alligator());
                        addMap.monsterList.Add(BabyDesertWolf());
                        addMap.monsterList.Add(Alligator());
                        addMap.monsterList.Add(BabyDesertWolf());
                        break;
                    case 2:
                        addMap.monsterList.Add(Alligator());
                        addMap.monsterList.Add(ElderWillow());
                        addMap.monsterList.Add(Galapago());
                        addMap.monsterList.Add(ElderWillow());
                        addMap.monsterList.Add(Obeaune());
                        addMap.monsterList.Add(Blazer());
                        break;
                    case 3:
                        addMap.monsterList.Add(Jakk());
                        addMap.monsterList.Add(Sohee());
                        addMap.monsterList.Add(Jakk());
                        addMap.monsterList.Add(Sohee());
                        addMap.monsterList.Add(Sting());
                        break;
                    case 4:
                        addMap.monsterList.Add(Baphomet());
                        break;
                    default:
                        break;
                }
                MapList.Add(addMap);
                addMap = null;
            }
            Update();
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
        private Monster Chonchon()
        {
            Monster monster = new Monster();
            monster.AttackDamage = 2;
            monster.EXP = 20;
            monster.MaxHP = monster.HP = 100;
            monster.Name = "Chonchon";
            monster.Death = false;
            return monster;
        }
        private Monster Flora()
        {
            Monster monster = new Monster();
            monster.AttackDamage = 2;
            monster.EXP = 20;
            monster.MaxHP = monster.HP = 100;
            monster.Name = "Flora";
            monster.Death = false;
            return monster;
        }
        private Monster Galapago()
        {
            Monster monster = new Monster();
            monster.AttackDamage = 2;
            monster.EXP = 20;
            monster.MaxHP = monster.HP = 100;
            monster.Name = "Galapago";
            monster.Death = false;
            return monster;
        }
        private Monster Jakk()
        {
            Monster monster = new Monster();
            monster.AttackDamage = 2;
            monster.EXP = 20;
            monster.MaxHP = monster.HP = 100;
            monster.Name = "Jakk";
            monster.Death = false;
            return monster;
        }
        private Monster LeafCat()
        {
            Monster monster = new Monster();
            monster.AttackDamage = 2;
            monster.EXP = 20;
            monster.MaxHP = monster.HP = 100;
            monster.Name = "LeafCat";
            monster.Death = false;
            return monster;
        }
        private Monster ElderWillow()
        {
            Monster monster = new Monster();
            monster.AttackDamage = 2;
            monster.EXP = 20;
            monster.MaxHP = monster.HP = 100;
            monster.Name = "ElderWillow";
            monster.Death = false;
            return monster;
        }
        private Monster Blazer()
        {
            Monster monster = new Monster();
            monster.AttackDamage = 2;
            monster.EXP = 20;
            monster.MaxHP = monster.HP = 100;
            monster.Name = "Blazer";
            monster.Death = false;
            return monster;
        }
        private Monster Obeaune()
        {
            Monster monster = new Monster();
            monster.AttackDamage = 2;
            monster.EXP = 20;
            monster.MaxHP = monster.HP = 100;
            monster.Name = "Obeaune";
            monster.Death = false;
            return monster;
        }
        private Monster Sohee()
        {
            Monster monster = new Monster();
            monster.AttackDamage = 2;
            monster.EXP = 20;
            monster.MaxHP = monster.HP = 100;
            monster.Name = "Sohee";
            monster.Death = false;
            return monster;
        }
        private Monster Sting()
        {
            Monster monster = new Monster();
            monster.AttackDamage = 2;
            monster.EXP = 20;
            monster.MaxHP = monster.HP = 100;
            monster.Name = "Sting";
            monster.Death = false;
            return monster;
        }
        private Monster Baphomet()
        {
            Monster monster = new Monster();
            monster.AttackDamage = 2;
            monster.EXP = 20;
            monster.MaxHP = monster.HP = 100;
            monster.Name = "Baphomet";
            monster.Death = false;
            return monster;
        }
    }
}
