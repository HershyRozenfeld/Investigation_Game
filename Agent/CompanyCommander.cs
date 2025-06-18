using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigation_Game
{
    public class CompanyCommander : Agent
    {
        public CompanyCommander(string[] weaknesses) : base(weaknesses)
        {
            Name = "CompanyCommander";
            GetNumOfWeaknesses();
            GetRandomWeakness();
            ArrToDictionary();
        }
    }
}
