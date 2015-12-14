using System.Collections.Generic;
using System.Drawing;

namespace RukNarok
{
    class Skill
    {
        private Image player;
        internal Image Player
        {
            get;
            set;
        }
        private Image monster;
        internal Image Monster
        {
            get;
            set;
        }

        private int damage;
        internal int Damage
        {
            get;
            set;
        }
    }
}
