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

        public Agent(string[] weaknesses) // כרגע בדרך הטיפשה עם מערך של חולשות
        {
            RndOfWeakness = new string[weaknesses.Length];
            RndOfWeakness = weaknesses;
        }
        public void GetNumOfWeaknesses()
        {
            switch (Name)
            {
                case "JuniorAgent":
                    NumOfWeaknesses = 2;
                    break;
                case "SeniorAgent":
                    NumOfWeaknesses = 4;
                    break;
                case "SquadLeader":
                    NumOfWeaknesses = 6;
                    break;
                case "CompanyCommander":
                    NumOfWeaknesses = 8;
                    break;
                default:
                    NumOfWeaknesses = 2;
                    break;
            }
        }
        public void GetRandomWeakness()
        {
            Random rnd = new Random();
            Weaknesses = new string[NumOfWeaknesses];
            for (int i = 0; i < NumOfWeaknesses; i++)
            {
                Weaknesses[i] = RndOfWeakness[rnd.Next(RndOfWeakness.Length)];
            }
        }
        public void Investigation(string sensor)
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
        public bool CompareWeaknessDictionaries()
        {
            if (DictOfWeaknesses.Count != InvestigationAttempt.Count)
            {
                return false;
            }
            foreach (var w in DictOfWeaknesses)
            {
                if (!InvestigationAttempt.TryGetValue(w.Key, out int value) || w.Value != value)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
