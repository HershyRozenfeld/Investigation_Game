using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigation_Game
{
    public class JuniorAgent : Agent
    {
        public JuniorAgent(Sensor[] weaknesses) : base(weaknesses)
        {
            Name = "JuniorAgent";
        }
    }
}
