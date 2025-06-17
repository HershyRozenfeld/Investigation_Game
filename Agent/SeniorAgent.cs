using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigation_Game
{
    internal class SeniorAgent : Agent
    {
        public SeniorAgent(string[] weaknesses) : base(weaknesses)
        {
            Name = "SeniorAgent";
        }
    }
}
