using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Project_Euler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter problem # to solve (1-517):");
            //int probNum = Int32.Parse(Console.ReadLine());
            int probNum = 3;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            switch (probNum)
            {
                case 0:
                    Console.WriteLine("Pi Time!:\n");
                    new Pi().Solve();
                    break;
                case 1:
                    Console.WriteLine("Problem 1:\n");
                    new Problem1().Solve();
                    break;
                case 2:
                    Console.WriteLine("Problem 2:\n");
                    new Problem2().Solve();
                    break;
                case 3:
                    Console.WriteLine("Problem 3:\n");
                    new Problem3().Solve();
                    break;
                case 4:
                    Console.WriteLine("Problem 4:\n");
                    new Problem4().Solve();
                    break;
                case 5:
                    Console.WriteLine("Problem 5:\n");
                    new Problem5().Solve();
                    break;
                case 6:
                    Console.WriteLine("Problem 6:\n");
                    new Problem6().Solve();
                    break;
                case 7:
                    Console.WriteLine("Problem 7:\n");
                    new Problem7().Solve();
                    break;
                case 8:
                    Console.WriteLine("Problem 8:\n");
                    new Problem8().Solve();
                    break;
                case 9:
                    Console.WriteLine("Problem 9:\n");
                    new Problem9().Solve();
                    break;
                case 10:
                    Console.WriteLine("Problem 10:\n");
                    new Problem10().Solve();
                    break;
                case 11:
                    Console.WriteLine("Problem 11:\n");
                    new Problem11().Solve();
                    break;
                case 12:
                    Console.WriteLine("Problem 12:\n");
                    new Problem12().Solve();
                    break;
                case 13:
                    Console.WriteLine("Problem 13:\n");
                    new Problem13().Solve();
                    break;
                default:
                    Console.WriteLine("Problem not yet solved:\n");
                    break;
            }
            stopwatch.Stop();
            Console.WriteLine("Finished in " + stopwatch.Elapsed + " seconds");
            Console.Read();
        }
    }
}
