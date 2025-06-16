using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigation_Game
{
    internal class CompanyCommander : Agent
    {
        public CompanyCommander(Sensor[] weaknesses) : base(weaknesses)
        {
            Name = "CompanyCommander";
        }
    }
}
