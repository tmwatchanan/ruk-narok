using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace RukNarok
{
    public class Model
    {
        protected ArrayList ObserverList;

        public Model()
        {
            ObserverList = new ArrayList();
        }

        public void NotifyAll()
        {
            foreach (View view in ObserverList)
            {
                view.Notify(this);
            }
        }

        public void AttachObserver(View view)
        {
            ObserverList.Add(view);
        }

    }
}
