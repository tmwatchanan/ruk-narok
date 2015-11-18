using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RukNarok
{
    class Player : Character
    {
        private string className;
        internal string ClassName
        {
            get;
            set;
        }

        public Player() : base()
        {
            ClassName = "Unknown";
        }

        protected void Attack()
        {

        }
    }
}
