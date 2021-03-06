﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeBuilding.Lib.Interfaces;
using HomeBuilding.Lib.Models.HomeBuilding.Lib.Models.Home;
using GeneratorName;
using HomeBuilding.Lib.Models.HomeBuilding.Lib.Models.Team;

namespace HomeBuilding.Lib.Models
{
   public class Project
    {
        public List<IPart> ListWork = new List<IPart>();
        public List<IWorker> Workers = new List<IWorker>();
        
        Random rnd = new Random();
        public void CreateWorks()
        {

            //Basement basement = new Basement();
            //basement.Company = "Asar";
            //basement.Count = rnd.Next(1,3);
            //basement.Material = "-";
            // basement.Price = rnd.Next();

            int c = rnd.Next(1, 3);
            int id = 0;
            for (int i = 0; i < c; i++)
            {
                Basement basement = new Basement();
                basement.WorkId = id++;
                basement.Company = "Asar";
                basement.Count = 1;
                basement.Material = "-";
                basement.Price = rnd.Next();
                ListWork.Add(basement);
            }

            for (int i = 0; i < c * 4; i++)
            {
                Walls wall = new Walls();
                wall.WorkId = id++;
                wall.Company = "-";
                wall.Count = 1;
                wall.Material = " kirpish";
                wall.SizeX = 10;
                wall.SizeY = 3;
                wall.Price = wall.SizeX * wall.SizeY * 15;
                wall.Color = ConsoleColor.Gray;
                ListWork.Add(wall);
            }

            for (int i = 0; i < rnd.Next(2, c * 6); i++)
            {
                Window window = new Window();
                window.WorkId = id++;

                window.Company = "--";
                window.Count = 1;
                window.Material = "plstik";
                window.Price = rnd.Next(10000, 80000);
                window.SizeX = 1000;
                window.SizeY = 800;
                ListWork.Add(window);
            }

            for (int i = 0; i < c * 4; i++)
            {
                Door door = new Door();
                door.WorkId = id++;

                door.Material = "derevo";
                door.Company = "---";
                door.Count = 1;
                door.SizeX = 1800;
                door.SizeY = 800;
                door.Price = 50000;
                ListWork.Add(door);
            }

            ListWork.Add(new Roof() { WorkId = id, Count = 1, Price = rnd.Next() });

        }

        public void CreateTeam()
        {
            int count = rnd.Next(5, 10);

            for (int i = 0; i < count; i++)
            {
                Worker worker = new Worker();
                worker.FIO = GetUserName();
                worker.Age = rnd.Next(20, 50);
                worker.Spec = (Spec)rnd.Next(0, 3);
                worker.SalaryInHour = rnd.Next(800, 3500);
                Workers.Add(worker);
            }

            TeamLeader leader = new TeamLeader();
            leader.FIO = GetUserName();
            leader.Age = rnd.Next(20, 50);
            leader.SalaryInHour = rnd.Next(800, 3500);
            leader.Brigada = Workers;

            Workers.Add(leader);
        }

        private string GetUserName()
        {
            Generator genName = new Generator();
            return genName.GenerateDefault((Gender)rnd.Next(2))
                 .Replace("<center><b><font size=7>", "")
                 .Replace("</font></b></center>", "")
                 .Replace("\n", "")
                 .Substring(1);
        }
        public void StartWork()
        {
            TeamLeader leader = (TeamLeader)Workers
                .FirstOrDefault(f => f.IsTeam == true);
            DateTime stw = DateTime.Now;
            DateTime fw = stw;
            for (int i = 0; i < ListWork.Count; i++)
            {
                Worker w = leader[leader.GetWorkerId()];
                if ((fw - stw).TotalDays > 20)
                {
                    leader.GetReport(ListWork);
                    fw = stw;
                }
                else
                {
                    IPart p = GetWork();
                    if (p != null)
                    {
                        int workOut = rnd.Next(1, 30);
                        ListWork[p.WorkId].DateStart = fw;
                        ListWork[p.WorkId].DateFinish =
                            ListWork[p.WorkId].DateStart
                            .AddDays(workOut);

                        fw = fw.AddDays(workOut);

                        ListWork[p.WorkId].Worker = w;
                        Console.WriteLine("done");
                    }
                }
            }        
        }

        private IPart GetWork()
        {
            //ListWork = ListWork
            //   .OrderBy(o => o.Sort)
            //   .ToList();

            return ListWork
               .Where(w => w.DateStart == DateTime.MinValue)
               .FirstOrDefault();
        }
    }
}
