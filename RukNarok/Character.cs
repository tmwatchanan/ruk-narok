using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RukNarok
{
    abstract class Character
    {
        private string name;
        private int hp;
        private int exp;
        private int attackDamage;
        private int x;
        private int y;
        private string className;
        
        public Character()
        {
            name = "Unknown";
            hp = -1;
            exp = -1;
            attackDamage = 0;
            x = 0;
            y = 0;
            className = "Novice";
        }

        abstract protected void Attack();
    }
}
