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
      public  class TeamLeader : IWorker
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

            public void GetReport(List<IPart> works)
            {
                foreach (IPart item in works)
                {
                    if (item.DateStart != DateTime.MinValue
                        && item.DateFinish != DateTime.MinValue)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("{0}\n{1} - {2}\n{3}days\ntotal time:{4}\nWorker:{5}\nSalary:{6}",
                            item.WorkId,
                            item.DateStart, item.DateFinish,
                            item.WorkOut.TotalDays,
                            item.WorkOut.TotalHours,
                            item.Worker.FIO,
                            item.WorkOut.TotalHours * item.Worker.SalaryInHour);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("------------------------------------");
                    }
                    else if (item.DateStart != null && item.DateFinish == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("{0}\n{1}\nWorker:{2}",
                            item.WorkId,
                            item.DateStart, item.Worker.FIO);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("------------------------------------");
                    }
                    //else
                    //{
                    //    Console.ForegroundColor = ConsoleColor.Red;
                    //    Console.WriteLine("{0}",item.WorkId);
                    //    Console.ForegroundColor = ConsoleColor.Gray;
                    //    Console.WriteLine("------------------------------------");
                    //}
                }
            }

        }
    }
}
