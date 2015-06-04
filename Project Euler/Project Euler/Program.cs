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
            int probNum = 77;
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
                case 14:
                    Console.WriteLine("Problem 14:\n");
                    new Problem14().Solve();
                    break;
                case 16:
                    Console.WriteLine("Problem 16:\n");
                    new Problem16().Solve();
                    break;
                case 20:
                    Console.WriteLine("Problem 20:\n");
                    new Problem20().Solve();
                    break;
                case 25:
                    Console.WriteLine("Problem 25:\n");
                    new Problem25().Solve();
                    break;
                case 56:
                    Console.WriteLine("Problem 56:\n");
                    new Problem56().Solve();
                    break;
                case 63:
                    Console.WriteLine("Problem 63:\n");
                    new Problem63().Solve();
                    break;
                case 77:
                    Console.WriteLine("Problem 77:\n");
                    new Problem77().Solve();
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
