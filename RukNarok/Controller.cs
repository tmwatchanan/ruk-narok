using System;
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
        
        public virtual void ActionPerformed(int action)
        {
            throw new NotImplementedException();
        }
        
        public virtual void MapChanged(int mapStage)
        {
            throw new NotImplementedException();
        }

        public virtual void ToggleMenu()
        {
            throw new NotImplementedException();
        }
    }
}
