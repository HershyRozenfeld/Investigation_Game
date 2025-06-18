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

        public InvestigationManager()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    Advanced Investigation Game                ║");
            Console.WriteLine("╠═══════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║ Goal: Discover all weaknesses of each agent using sensors     ║");
            Console.WriteLine("║                                                               ║");
            Console.WriteLine("║ How it works:                                                 ║");
            Console.WriteLine("║ • Each agent has a rank and a random set of weaknesses        ║");
            Console.WriteLine("║ • You must guess which sensor reveals each weakness           ║");
            Console.WriteLine("║ • If an agent has 2 weaknesses of the same type,              ║");
            Console.WriteLine("║   you must select that sensor twice                           ║");
            Console.WriteLine("║ • Only after discovering all weaknesses you move to next      ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
        }

        public void PrintAllAgents()
        {
            Console.WriteLine("┌─────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                    Agents List                          │");
            Console.WriteLine("├─────────────────────────────────────────────────────────┤");

            if (Agents.Count == 0)
            {
                Console.WriteLine("│ No agents available                                     │");
                Console.WriteLine("└─────────────────────────────────────────────────────────┘");
                return;
            }

            for (int i = 0; i < Agents.Count; i++)
            {
                Console.WriteLine($"│ {i + 1}: {Agents[i].Name,-20} ({Agents[i].NumOfWeaknesses} weaknesses) │");
            }
            Console.WriteLine("└─────────────────────────────────────────────────────────┘");
        }

        public void PrintAgent(Agent agent)
        {
            Console.WriteLine("┌──────────────────────────────────────────────────────────");
            Console.WriteLine($"│                Agent Details: {agent.Name,-20}           ");
            Console.WriteLine("├──────────────────────────────────────────────────────────");
            Console.WriteLine($"│ Rank: {agent.Name,-30}                                  ");
            Console.WriteLine($"│ Number of weaknesses: {agent.NumOfWeaknesses,-10}                ");

            if (agent.Weaknesses != null && agent.Weaknesses.Length > 0)
            {
                Console.WriteLine("│ Hidden weaknesses (for testing only):                   ");
                var weaknessGroups = agent.Weaknesses.GroupBy(w => w).ToDictionary(g => g.Key, g => g.Count());
                foreach (var weakness in weaknessGroups)
                {
                    Console.WriteLine($"│   {weakness.Key}: {weakness.Value} times                          ");
                }
            }

            if (agent.InvestigationAttempt.Count > 0)
            {
                Console.WriteLine("│ Your attempts so far:                                   ");
                foreach (var attempt in agent.InvestigationAttempt)
                {
                    Console.WriteLine($"│   {attempt.Key}: {attempt.Value} times                          ");
                }
            }

            Console.WriteLine("└──────────────────────────────────────────────────────────");
        }

        public void PrintAllSensors()
        {
            Console.WriteLine("┌─────────────────────────────────────────────────────────┐");
            Console.WriteLine("│                    Sensors List                         │");
            Console.WriteLine("├─────────────────────────────────────────────────────────┘");

            if (AllSensors.Count == 0)
            {
                Console.WriteLine("│ No sensors available                                    │");
                Console.WriteLine("└─────────────────────────────────────────────────────────┘");
                return;
            }

            for (int i = 0; i < AllSensors.Count; i++)
            {
                Console.WriteLine($"│ {i + 1}: {AllSensors[i].Name,-30}                ");
            }
            Console.WriteLine("└──────────────────────────────────────────────────────────");
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
            Console.WriteLine("                🎮 Let's start the investigation! 🎮\n");

            int agentNumber = 1;
            while (Agents.Count > 0)
            {
                Agent currentAgent = Agents[0];
                Console.WriteLine($"╔═══════════════════════════════════════════════════════════════╗");
                Console.WriteLine($"║                Investigating Agent {agentNumber}/{Agents.Count + agentNumber - 1}                        ║");
                Console.WriteLine($"╚═══════════════════════════════════════════════════════════════╝");
                
                currentAgent.InvestigationAttempt.Clear();
                bool agentCompleted = false;
                bool needsNewInvestigation = true;

                while (!agentCompleted)
                {
                    PrintAgent(currentAgent);

                    if (needsNewInvestigation)
                    {
                        InvestigateAgent(currentAgent);
                        needsNewInvestigation = false;
                    }

                    // Check if all weaknesses were found
                    if (currentAgent.CompareWeaknessDictionaries())
                    {
                        Console.WriteLine("🎉 Great! You discovered all the agent's weaknesses! 🎉\n");
                        agentCompleted = true;
                        RemoveAgent(currentAgent);
                        agentNumber++;
                    }
                    else
                    {
                        Console.WriteLine("❌ Not all weaknesses were discovered. Try again!");
                        Console.WriteLine("💡 Tip: Maybe you missed some weaknesses or selected a sensor too many times\n");

                        // Option to change previous choices
                        Console.WriteLine("Would you like to change previous choices? (y/n)");
                        string response = Console.ReadLine()?.ToLower();
                        Console.WriteLine("\n");
                        if (response == "y" || response == "yes")
                        {
                            ModifyPreviousChoices(currentAgent);
                        }
                        else
                        {
                            // Reset attempts and start over
                            currentAgent.InvestigationAttempt.Clear();
                            Console.WriteLine("🔄 Restarting with this agent...\n");
                            needsNewInvestigation = true;
                        }
                    }
                }
            }

            Console.WriteLine("🏆🎊 Congratulations! You completed the investigation successfully! All weaknesses were discovered! 🎊🏆");
            Console.WriteLine("Game over!");
        }

        private int GetSensorSelection(string prompt)
        {
            int sensorId;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (int.TryParse(input, out sensorId) && sensorId > 0 && sensorId <= AllSensors.Count)
                {
                    return sensorId - 1;
                }
                Console.WriteLine($"❌ Invalid input. Please enter a number between 1 and {AllSensors.Count}");
            }
        }

        private void InvestigateAgent(Agent agent)
        {
            Console.WriteLine($"\n🔍 Investigating {agent.Name} - need to find {agent.NumOfWeaknesses} weaknesses");
            Console.WriteLine("Select sensors to discover the weaknesses:\n");

            for (int i = 0; i < agent.NumOfWeaknesses; i++)
            {
                Console.WriteLine($"───── Choice {i + 1}/{agent.NumOfWeaknesses} ─────");
                PrintAllSensors();

                int sensorId = GetSensorSelection($"🎯 Select a sensor (1-{AllSensors.Count}): ");

                bool success = AllSensors[sensorId].Activate(agent);
                agent.Investigation(AllSensors[sensorId].Name);

                Console.WriteLine(success ? "✅ Hit! The sensor discovered a weakness!" : "❌ Miss. The sensor did not discover a weakness.");
                Console.WriteLine($"You selected: {AllSensors[sensorId].Name}");
                Console.WriteLine();
            }

            // Show summary
            Console.WriteLine("📊 Your choices summary:");
            foreach (var attempt in agent.InvestigationAttempt)
            {
                Console.WriteLine($"   {attempt.Key}: {attempt.Value} times");
            }
            Console.WriteLine();
        }

        private void ModifyPreviousChoices(Agent agent)
        {
            if (agent.InvestigationAttempt.Count == 0)
            {
                Console.WriteLine("No previous choices to change.");
                return;
            }

            Console.WriteLine("📝 Your current choices:");
            var keys = new List<string>();
            int index = 1;
            foreach (var kvp in agent.InvestigationAttempt)
            {
                Console.WriteLine($"{index}. {kvp.Key}: {kvp.Value} times");
                keys.Add(kvp.Key);
                index++;
            }

            Console.Write("Select which choice to change (number): ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= keys.Count)
            {
                string oldKey = keys[choice - 1];

                Console.WriteLine("Select a new sensor:");
                PrintAllSensors();
                int newSensorId = GetSensorSelection("New sensor number: ");

                // Decrease old choice
                if (agent.InvestigationAttempt[oldKey] > 1)
                {
                    agent.InvestigationAttempt[oldKey]--;
                }
                else
                {
                    agent.InvestigationAttempt.Remove(oldKey);
                }

                // Add new choice
                agent.Investigation(AllSensors[newSensorId].Name);

                Console.WriteLine($"✓ Changed from {oldKey} to {AllSensors[newSensorId].Name}");
            }
            else
            {
                Console.WriteLine("❌ Invalid choice.");
            }
        }
    }
}