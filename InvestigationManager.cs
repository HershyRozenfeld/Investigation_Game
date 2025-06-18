using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigation_Game
{
    internal class InvestigationManager
    {
        private List<Agent> Agents = new List<Agent>();
        private List<Sensor> AllSensors = new List<Sensor>();
        public Dictionary<string, int> DictOfWeaknesses;
        public Dictionary<string, int> InvestigationAttempt;
        public InvestigationManager()
        {

        }
        public void PrintAllAgents()
        {
            Console.WriteLine("=== List of Agents ===");
            if (Agents.Count == 0)
            {
                Console.WriteLine("No agents available.");
                return;
            }
            for (int i = 0; i < Agents.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {Agents[i].Name} (Rank: {Agents[i].Name}, Weaknesses: {Agents[i].NumOfWeaknesses})");
            }
            Console.WriteLine("======================");
        }
        public void PrintAgent(Agent agent)
        {
            Console.WriteLine("=== Agent Details ===");
            Console.WriteLine($"Rank: {agent.Name}");
            Console.WriteLine($"Number of Weaknesses: {agent.NumOfWeaknesses}");
            if (agent.Weaknesses != null && agent.Weaknesses.Length > 0)
            {
                Console.WriteLine("Weaknesses:");
                for (int i = 0; i < agent.Weaknesses.Length; i++)
                {
                    Console.WriteLine($"  {i + 1}. {agent.Weaknesses[i]}");
                }
            }
            else
            {
                Console.WriteLine("No weaknesses listed.");
            }
            Console.WriteLine("=====================");
        }
        public void PrintAllSensors()
        {
            Console.WriteLine("=== List of Sensors ===");
            if (AllSensors.Count == 0)
            {
                Console.WriteLine("No sensors available.");
                return;
            }
            for (int i = 0; i < AllSensors.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {AllSensors[i].Name}");
            }
            Console.WriteLine("=======================");
        }
        public void AddAgent(Agent agent)
        {
            Agents.Add(agent);
        }
        public void RemoveAgent(Agent agent)
        {
            Agents.Remove(agent);
        }
        public void AddSensor(Sensor sensor)
        {
            AllSensors.Add(sensor);
        }

        public void StartInvestigation()
        {
            Console.WriteLine("Select an agent by entering the corresponding number:");
            while (0 < Agents.Count)// עד שכל הסוכנים הוצמדו
            {
                bool flag = false;
                PrintAllAgents();
                while (!flag)// עד שחלה הצלחה על סוכן ספציפי
                {
                    if (!InvestigateAgent(Agents[0]))// עד שהחקירה הראשונה הצליחה
                    {
                        while (!flag)
                        {
                            OverwriteDictionaryValue(Agents[0]);
                            flag = Agents[0].CompareWeaknessDictionaries();
                        }
                    }
                    RemoveAgent(Agents[0]);
                }
            }
            Console.WriteLine("Investigation complete! All weaknesses found. GAME OVER!");
        }

        private int GetSensorSelection(string prompt)
        {
            int sensorId;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out sensorId) && sensorId > 0 && sensorId <= AllSensors.Count)
                {
                    return sensorId - 1;
                }
                Console.WriteLine("Invalid input. Please enter a valid sensor number.");
            }
        }

        private bool InvestigateAgent(Agent agent)
        {
            //agent.InvestigationAttempt.Clear();
            int count = 0;
            for (int i = 0; i < agent.NumOfWeaknesses; i++)
            {
                Console.WriteLine($"\n--- Round {i + 1}/{agent.NumOfWeaknesses} ---");
                PrintAgent(agent); // לצורך בדיקה בלבד
                Console.WriteLine("Select a sensor to use by entering the corresponding number:");
                PrintAllSensors();
                int sensorId = GetSensorSelection("Enter sensor number: ");
                bool flag = AllSensors[sensorId].Activate(agent);
                Console.WriteLine(flag ? "BOOM! Success." : "Failure.");
                if (flag)
                {
                    count++;
                }
                agent.Investigation(AllSensors[sensorId].Name);
            }
            Console.WriteLine($"\n=== Investigation Result: {count}/{agent.NumOfWeaknesses} Successes ===");
            if (count < agent.NumOfWeaknesses)
            {
                Console.WriteLine("Not all weaknesses were found. Retrying investigation...\n");
                return false;
            }
            return true;
        }

        private int SelectIndexFromList(List<string> items, string prompt)
        {
            int selectedIndex = -1;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out selectedIndex) && selectedIndex > 0 && selectedIndex <= items.Count)
                {
                    return selectedIndex - 1;
                }
                Console.WriteLine("Invalid input. Please enter a valid index.");
            }
        }

        private List<string> PrintDictionaryEntries(Dictionary<string, int> dict)
        {
            var keys = new List<string>();
            int index = 1;
            foreach (var kvp in dict)
            {
                Console.WriteLine($"{index}. {kvp.Key}: {kvp.Value}");
                keys.Add(kvp.Key);
                index++;
            }
            return keys;
        }

        private void OverwriteDictionaryValue(Agent agent)
        {
            var dict = agent.InvestigationAttempt;
            if (dict.Count == 0)
            {
                Console.WriteLine("No entries in the dictionary to overwrite.");
                return;
            }

            var keys = PrintDictionaryEntries(dict);
            int oldKeyIndex = SelectIndexFromList(keys, "Enter the index of the key you want to overwrite: ");
            string oldKey = keys[oldKeyIndex];

            PrintAllSensors();
            int newKeyIndex = GetSensorSelection("Enter sensor number for the new key: ");

            if (dict[oldKey] > 1)
            {
                dict[oldKey]--;
            }
            else
            {
                dict.Remove(oldKey);
            }

            agent.Investigation(AllSensors[newKeyIndex].Name);
            Console.WriteLine($"Entry updated: {oldKey} -> {AllSensors[newKeyIndex].Name}: {dict[AllSensors[newKeyIndex].Name]}");
        }
    }
}
