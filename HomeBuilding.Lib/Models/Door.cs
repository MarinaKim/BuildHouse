using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeBuilding.Lib.Interfaces;

namespace HomeBuilding.Lib.Models
{
    namespace HomeBuilding.Lib.Models.Home
    {
       public class Door : IPart
        {
            public int WorkId { get; set; }

            public double SizeX { get; set; }
            public double SizeY { get; set; }

            public ConsoleColor Color { get; set; } = ConsoleColor.White;
            public string Company { get; set; }

            public int Count { get; set; }
            private DateTime DateFinish_;

            public DateTime DateFinish
            {
                get
                {
                    return DateFinish_;
                }

                set
                {
                    DateFinish_ = value;
                    if (DateStart == null || DateStart == DateTime.MinValue)
                    {
                        DateStart = value;
                    }
                    WorkOut =
                        TimeSpan.FromHours((DateFinish_ - DateStart).TotalHours);
                }
            }
            public DateTime DateStart { get; set; }

            public string Material { get; set; }

            public double Price { get; set; }

            public int Sort { get; set; } = 2;
            public IWorker Worker { get; set; }
            public TimeSpan WorkOut { get; set; }

        }
    }
}
