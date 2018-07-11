using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBuilding.Lib.Interfaces
{
  public  interface IPart
    {
        int WorkId { get; set; }

        int Sort { get; set; }
        double Price { get; set; }
        string Material { get; set; }
        int Count { get; set; }
        string Company { get; set; }

        IWorker Worker { get; set; }
        TimeSpan WorkOut { get; set; }

        DateTime DateStart { get; set; }
        DateTime DateFinish { get; set; }

    }
}
