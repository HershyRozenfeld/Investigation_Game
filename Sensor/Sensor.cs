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
            int value;
            if (agent.DictOfWeaknesses.ContainsKey(Name))
            {
                value = agent.DictOfWeaknesses[Name];
                if (!agent.InvestigationAttempt.ContainsKey(Name))
                {
                    return true;
                }
                else if (agent.InvestigationAttempt[Name] == value - 1)
                {
                    return true;
                }
            }
            return false;
        }


    }

}
