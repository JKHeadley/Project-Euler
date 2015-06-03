using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Euler.Helpers;

namespace Project_Euler
{
    /// <summary>
    /// 
    /// </summary>
    class Problem13
    {
        public void Solve()
        {
            System.IO.StreamReader file = new System.IO.StreamReader("../../Text Files/50digitnums.txt");
            string line = "x";
            BigNum sum = 0, num = 0;
            while (!file.EndOfStream)
            {
                line = file.ReadLine();
                Console.WriteLine(line);
                num = new BigNum(line);
                sum = sum + num;
            }
            Console.WriteLine("\nThe sum of the numbers is:\n" + (string)sum);
        }
    }
}
