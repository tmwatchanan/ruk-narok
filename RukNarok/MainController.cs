using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RukNarok
{
    public class MainController : Controller
    {
        public override void ActionPerformed(int action)
        {
            foreach (Model model in ModelList)
            {
                if (model is MapModel)
                {
                    MapModel mapModel = (MapModel)model;

                }
            }
        }
    }
}
