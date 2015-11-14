using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace RukNarok
{
    public class Controller
    {
        protected ArrayList ModelList;

        public Controller()
        {
            ModelList = new ArrayList();
        }

        public void AddModel(Model model)
        {
            ModelList.Add(model);
        }

        // virtual keyword allow the method to be overriden
        public virtual void ActionPerformed(int action)
        {
            throw new NotImplementedException();
        }
    }
}
