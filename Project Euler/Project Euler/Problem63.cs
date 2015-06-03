using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Euler.Helpers;

namespace Project_Euler
{
    class Problem63
    {
        /// <summary>
        /// Powerful digit counts
        /// 
        /// The 5-digit number, 16807=7^5, is also a fifth power. Similarly, the 9-digit number, 134217728=8^9, is a ninth power.
        /// 
        /// How many n-digit positive integers exist which are also an nth power?
        /// </summary>
        public void Solve()
        {
            BigNum exp = 1, pow = 0, _base = 1;
            int count = 0, finish = 0;
            while (true)
            {
                for (; pow.GetDigitsSize() <= exp; _base++)
                {
                    pow = _base ^ exp;
                    //Console.WriteLine((string)pow);
                    if (pow.GetDigitsSize() == exp)
                    {
                        count++;
                        finish++;
                        Console.WriteLine(exp + " = digit count of " + (string)pow + " which = " + (string)_base + "^" + (string)exp);
                    }
                }
                if (finish == 0)
                    break;
                exp++;
                _base = 1;
                finish = 0;
            }

            Console.WriteLine("Number of n-digit positive integers which are also an nth power is: " + count);
        }
    }
}
