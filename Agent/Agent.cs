using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigation_Game
{
    public abstract class Agent
    {
        public string Name { get; set; }
        public string Rank { get; set; } 
        public Sensor[] Weaknesses { get; protected set; }
        public Sensor[] RndOfWeakness { get; set; }

        public Dictionary<Sensor, int> InvestigationAttempt = new Dictionary<Sensor, int>();

        public Agent(string name, Sensor[] weaknesses, string rank = "JuniorAgent") // כרגע בדרך הטיפשה עם מערך של חולשות
        {                                                                
            Name = name;
            Rank = rank;
            RndOfWeakness = new Sensor[weaknesses.Length];
            RndOfWeakness = weaknesses;
        }
        public abstract void SetRandomWeakness();
        public void Investigation(Sensor sensor) // מקבל סנסור בודד, ומצפה שאת הלוגיקה של כמה סנסורים להכניס עבור כל סוכן למערכת הניהול
        {
            if (!InvestigationAttempt.ContainsKey(sensor))
            {
                InvestigationAttempt[sensor] = 1;
            }
            else
            {
                InvestigationAttempt[sensor]++;
            }
        }
    }
}
