using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RukNarok
{
    class Character
    {
        private string name;
        private int hp;
        private int exp;
        private int attackDamage;
        private Location position;

        internal string Name
        {
            get;
            set;
        }
        internal int HP
        {
            get;
            set;
        }
        internal int EXP
        {
            get;
            set;
        }
        internal int AttackDamage
        {
            get;
            set;
        }
        internal Location Position
        {
            get;
            set;
        }
        
        public Character()
        {
            Name = "Unknown";
            HP = -1;
            EXP = -1;
            AttackDamage = 0;
            //Position.X = 0;
            //Position.Y = 0;
        }
    }
}
