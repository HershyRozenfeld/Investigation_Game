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
        public int NumOfWeaknesses { get; set; }
        public string[] Weaknesses { get; protected set; }
        public string[] RndOfWeakness { get; set; }
        public Dictionary<string, int> DictOfWeaknesses = new Dictionary<string, int>();

        public Dictionary<string, int> InvestigationAttempt = new Dictionary<string, int>();

        public Agent(string[] weaknesses, string rank = "JuniorAgent") // כרגע בדרך הטיפשה עם מערך של חולשות
        {
            Rank = rank;
            RndOfWeakness = new string[weaknesses.Length];
            RndOfWeakness = weaknesses;
            switch (rank.ToLower())
            {
                case "junioragent":
                    NumOfWeaknesses = 2;
                    break;
                case "senioragent":
                    NumOfWeaknesses = 4;
                    break;
                case "squadleader":
                    NumOfWeaknesses = 6;
                    break;
                case "companycommander":
                    NumOfWeaknesses = 8;
                    break;
                default:
                    NumOfWeaknesses = 2;
                    break;
            }
            SetRandomWeakness();
        }
        public void SetRandomWeakness()
        {
            Random rnd = new Random();
            Weaknesses = new string[NumOfWeaknesses];
            for (int i = 0; i < NumOfWeaknesses; i++)
            {
                Weaknesses[i] = RndOfWeakness[rnd.Next(RndOfWeakness.Length)];
            }
        }
        public void Investigation(string sensor) // מקבל סנסור בודד, ומצפה שאת הלוגיקה של כמה סנסורים להכניס עבור כל סוכן למערכת הניהול
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
        public void ArrToDictionary()
        {
            for (int i = 0; i < NumOfWeaknesses; i++)
            {
                if (DictOfWeaknesses.ContainsKey(Weaknesses[i]))
                {
                    DictOfWeaknesses[Weaknesses[i]]++;
                }
                else
                {
                    DictOfWeaknesses[Weaknesses[i]] = 1;
                }
            }
        }
    }
}
