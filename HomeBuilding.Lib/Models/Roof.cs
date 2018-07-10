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
        class Roof : IPart
        {
            public ConsoleColor Color { get; set; } = ConsoleColor.White;
            public string Company { get; set; }

            public int Count { get; set; }
            public DateTime DateFinish { get; set; }

            public DateTime DateStart { get; set; }

            public string Material { get; set; }

            public double Price { get; set; }

            public int Sort { get; set; } = 4;
        }
    }
}
