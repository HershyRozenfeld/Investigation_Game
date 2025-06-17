using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigation_Game
{
    internal class InvestigationManager
    {
        private List<Agent> Agents;
        private List<Sensor> AllSensors;
        public Dictionary<string, int> DictOfWeaknesses;
        public Dictionary<string, int> InvestigationAttempt;
        public InvestigationManager()
        {

        }
        public void PrintAllAgents()
        {
            for (int i = 0; i < Agents.Count; i++)
            {
                Console.Write(i+1+" : ");
                Console.WriteLine(Agents[i].Name);
            }
        }
        public void PrintAgent(Agent agent)
        {
            Console.WriteLine(agent.Name);
        }
        public void PrintAllSensors()
        {
            for (int i = 0; i < AllSensors.Count; i++)
            {
                Console.Write(i + 1 + " : ");
                Console.WriteLine(AllSensors[i].Name);
            }
        }
        public void AddAgent(Agent agent)
        {
            Agents.Add(agent);
        }
        public void AddSensor(Sensor sensor)
        {
            AllSensors.Add(sensor);
        }
        public void StartInvestigation()
        {
            PrintAllAgents();
            int agentId = int.Parse(Console.ReadLine())-1;
            bool flag = false;
            int count = 0;
            for (int i = 0; i< Agents[agentId].NumOfWeaknesses; i++)
            {
                PrintAllSensors();
                int sensorId = int.Parse(Console.ReadLine()) - 1;
                DictOfWeaknesses = Agents[agentId].DictOfWeaknesses;
                InvestigationAttempt = Agents[agentId].InvestigationAttempt;
                flag = AllSensors[sensorId].Activate(Agents[agentId]);
                Console.WriteLine(flag ? "Success" : "Failure");
                if (flag)
                {
                    count++;
                }
                Agents[agentId].Investigation(AllSensors[sensorId].Name);
            }
            Console.WriteLine($"Success{count}/{Agents[agentId].NumOfWeaknesses}");
        }

    }
}
