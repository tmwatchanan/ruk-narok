using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RukNarok
{
    class Location
    {
        private int x;
        private int y;

        internal int X
        {
            get;
            set;
        }
        internal int Y
        {
            get;
            set;
        }
        
        public static bool operator ==(Location locationLeft, Location locationRight)
        {
            if (System.Object.ReferenceEquals(locationLeft, locationRight))
            {
                return true;
            }

            if (((object)locationLeft == null) || ((object)locationRight == null))
            {
                return false;
            }
            return ((locationLeft.X == locationRight.X) && (locationLeft.Y == locationRight.Y));
        }

        public static bool operator !=(Location f_left, Location locationRight)
        {
            return (f_left.X != locationRight.X || f_left.Y != locationRight.Y);
        }
    }
}
