using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeBuilding.Lib.Interfaces;

namespace HomeBuilding.Lib.Models
{
    namespace HomeBuilding.Lib.Models.Team
    {
        class TeamLeader : IWorker
        {
            public bool IsTeam { get; set; } = true;
            public int Age { get; set; }

            public string FIO { get; set; }

            public double SalaryInHour { get; set; }

            public Spec Spec { get; set; }

            public List<IWorker> Brigada = new List<IWorker>();

            Random rnd = new Random();
            //public  Worker GetWorker()
            //{
            //    return (Worker)Brigada.ElementAt(rnd.Next(0, Brigada.Count - 1));
            //}

            public int GetWorkerId()
            {
                return rnd.Next(0, Brigada.Count - 1);
            }

            public Worker this[int workerId]
            {
                get
                {
                    return (Worker)Brigada.ElementAt(workerId);
                }
            }
        }
    }
}
