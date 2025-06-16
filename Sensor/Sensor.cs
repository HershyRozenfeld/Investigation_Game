using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigation_Game
{
    public abstract class Sensor
    {
        public string Name { get; protected set; }
        public Sensor()
        {
        }

        public bool Activate(Agent agent)
        {
            if (agent.DictOfWeaknesses.ContainsKey(Name))
            {
                return true;
            }
            return false;
        }


    }

}
