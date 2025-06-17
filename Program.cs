using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Investigation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Agent> agents = new List<Agent>();
            List<Sensor> sensors = new List<Sensor>();

            // כאן אתה יכול להעביר מערך חולשות רלוונטי לכל סוכן
            string[] weaknesses = new string[] { "MotionSensor", "ThermalSensor", "CellularSensor" };
            // יצירת סוכנים (נניח 5 מכל סוג)
            for (int i = 0; i < 5; i++)
            {
                agents.Add(new JuniorAgent(weaknesses));
                agents.Add(new SeniorAgent(weaknesses));
                agents.Add(new SquadLeader(weaknesses));
                agents.Add(new CompanyCommander(weaknesses));
            }

            // יצירת סנסורים (נניח 5 מכל סוג)
            for (int i = 0; i < 5; i++)
            {
                sensors.Add(new MotionSensor());
                sensors.Add(new ThermalSensor());
                sensors.Add(new CellularSensor());
            }

            // דוגמה להוספה ל-InvestigationManager
            InvestigationManager manager = new InvestigationManager();
            foreach (var agent in agents)
                manager.AddAgent(agent);

            foreach (var sensor in sensors)
                manager.AddSensor(sensor);

            manager.StartInvestigation();
        }
    }
}
