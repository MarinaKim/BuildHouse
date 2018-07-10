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
        public class Worker : IWorker
        {
            public bool IsTeam { get; set; } = false;
            public int Age { get; set; }

            public string FIO { get; set; }

            public double SalaryInHour { get; set; }

            public Spec Spec { get; set; }
        }
    }
}

