using HomeBuilding.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            Project pr = new Project();
            pr.CreateWorks();
            pr.CreateTeam();
            pr.StartWork();
        }
    }
}
