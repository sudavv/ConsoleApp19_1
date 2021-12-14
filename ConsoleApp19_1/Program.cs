using System;

using System.Collections.Generic;

using System.IO;
using System.Linq;

namespace ConsoleApp3_4
{
    public class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {           
            List<PC> listPC = new List<PC>()
            {
                new PC {Code=1, Manufacter = "ASUS", TypeCPU = "Intel", Freq = 3900, RAM = 16, ROM = 512, VideoMem = 8, Cost = 100000, Count = 3},
                new PC {Code=2, Manufacter = "AsRock", TypeCPU = "AMD", Freq = 4900, RAM = 32, ROM = 2048, VideoMem = 16, Cost = 150000, Count = 1},
                new PC {Code=3, Manufacter = "Gigabyte", TypeCPU = "Intel", Freq = 2900, RAM = 4, ROM = 256, VideoMem = 4, Cost = 80000, Count = 2},
                new PC {Code=4, Manufacter = "MSI", TypeCPU = "AMD", Freq = 3000, RAM = 8, ROM = 512, VideoMem = 6, Cost = 90000, Count = 11},
                new PC {Code=5, Manufacter = "Zalman", TypeCPU = "Intel", Freq = 3400, RAM = 8, ROM = 500, VideoMem = 8, Cost = 95000, Count = 5},
                new PC {Code=6, Manufacter = "Apacer", TypeCPU = "AMD", Freq = 3600, RAM = 16, ROM = 1024, VideoMem = 12, Cost = 130000, Count = 6},
                new PC {Code=7, Manufacter = "Dexp", TypeCPU = "Intel", Freq = 3200, RAM = 8, ROM = 512, VideoMem = 8, Cost = 99000, Count = 32}
            };

            Console.WriteLine("Введите фирму CPU для отбора: Intel/AMD");
            string cpu = Console.ReadLine();
            Print(listPC
                .Where(c => c.TypeCPU.ToLower() == cpu.ToLower())
                .ToList());

            bool retry = true;
            while (retry)
            {
                try
                {
                    Console.WriteLine("Введите объем ОЗУ для отбора (Гб)");
                    int ram = Convert.ToInt32(Console.ReadLine());
                    Print(listPC
                       .Where(c => c.RAM > ram)
                       .ToList());
                    retry = false;
                }
                catch
                {
                    Console.WriteLine("Не число");
                }
            }

            Console.WriteLine("Нажмите любую клавишу, чтобы вывести список, отсортированный по стоимости");
            Console.ReadKey();
            Print((from c in listPC
                  orderby c.Cost
                  select c).ToList());

            Console.WriteLine("Нажмите любую клавишу, чтобы вывести список, сгруппированный по типу процессора");
            Console.ReadKey();
            Print((listPC.GroupBy( c => c.TypeCPU).ToList())[0].ToList());
            Print((listPC.GroupBy(c => c.TypeCPU).ToList())[1].ToList());

            Console.WriteLine("Нажмите любую клавишу, чтобы вывести самый дорогой и бюджетный товары");
            Console.ReadKey();

            var max = listPC.FirstOrDefault(a => a.Cost == listPC.Max(c => c.Cost));
            var min = listPC.FirstOrDefault(a => a.Cost == listPC.Min(c => c.Cost));
            List<PC> maxmin = new List<PC>();
            maxmin.Add(max);
            maxmin.Add(min);
            Print(maxmin);

            Console.WriteLine("Нажмите любую клавишу, чтобы вывести товары, в количестве не менее 30 штук");
            Console.ReadKey();
            Print(listPC
               .Where(c => c.Count > 29)
               .ToList());

            Console.ReadLine();
            Run();
            Environment.Exit(0);
        }
        public class PC
        {
            public int Code { get; set; }
            public string Manufacter { get; set; }
            public string TypeCPU { get; set; }
            public int Freq { get; set; }
            public int RAM { get; set; }
            public int ROM { get; set; }
            public int VideoMem { get; set; }
            public double Cost { get; set; }
            public int Count { get; set; }
        }

        public static void Print(List<PC> list) 
        {                    
                foreach (PC c in list)
                {
                    Console.WriteLine($"{c.Code} {c.Manufacter} {c.TypeCPU} {c.Freq} {c.RAM} {c.ROM} {c.VideoMem} {c.Cost} {c.Count}");
                }
            Console.WriteLine();
        }
    }
}



