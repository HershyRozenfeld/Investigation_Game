using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigation_Game
{
    public class SquadLeader : Agent
    {
        public SquadLeader(string[] weaknesses) : base(weaknesses)
        {
            Name = "SquadLeader";
            GetNumOfWeaknesses();
            GetRandomWeakness();
            ArrToDictionary();
        }
    }
}
