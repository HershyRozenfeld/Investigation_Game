using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigation_Game
{
    public class SeniorAgent : Agent
    {
        public SeniorAgent(string[] weaknesses) : base(weaknesses)
        {
            Name = "SeniorAgent";
            NumOfWeaknesses = 4;
            GetRandomWeakness();
            ArrToDictionary();
        }
        public Agent CounterAttack()
        {
            Agent agent = new JuniorAgent(Weaknesses);
            return agent;
        }

    }
}
