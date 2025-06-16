using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigation_Game
{
    public class JuniorAgent : Agent
    {
        Random rnd = new Random();
        public JuniorAgent(string name, Sensor[] weaknesses) : base(name, weaknesses)
        {
            SetRandomWeakness();
        }
        public override void SetRandomWeakness()
        {
            Random rnd = new Random();
            int weak1 = rnd.Next(RndOfWeakness.Length);
            int weak2 = rnd.Next(RndOfWeakness.Length);
            this.Weaknesses = new Sensor[] { RndOfWeakness[weak1], RndOfWeakness[weak2] };
        }
    }
}
