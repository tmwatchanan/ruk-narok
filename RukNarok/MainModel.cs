using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RukNarok
{
    class MainModel : Model
    {
        public MainModel()
        {
            
        }

        public void Update()
        {
            NotifyAll();
        }

    }
}
