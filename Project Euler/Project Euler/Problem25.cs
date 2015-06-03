using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Euler.Helpers;

namespace Project_Euler
{
    /// <summary>
    /// 1000-digit Fibonacci number
    /// 
    /// The Fibonacci sequence is defined by the recurrence relation:
    /// 
    /// Fn = Fn−1 + Fn−2, where F1 = 1 and F2 = 1.
    /// Hence the first 12 terms will be:
    /// 
    /// F1 = 1
    /// F2 = 1
    /// F3 = 2
    /// F4 = 3
    /// F5 = 5
    /// F6 = 8
    /// F7 = 13
    /// F8 = 21
    /// F9 = 34
    /// F10 = 55
    /// F11 = 89
    /// F12 = 144
    /// The 12th term, F12, is the first term to contain three digits.
    /// 
    /// What is the index of the first term in the Fibonacci sequence to contain 1000 digits?
    /// </summary>
    class Problem25
    {
        public void Solve()
        {
            BigNum F_n = 1, F_n1 = 1, F_n2 = 1;
            int sequence_index = 3;
            while (F_n.GetDigitsSize() < 1000)
            {
                F_n = F_n1 + F_n2;
                F_n2 = new BigNum(F_n1);
                F_n1 = new BigNum(F_n);
                //Console.WriteLine(sequence_index + " " + F_n);
                sequence_index++;
            }
            Console.WriteLine("First term in the Fibonacci sequence to contian 1000 digits is:" + --sequence_index + 
                "\nWith the value of:\n\n" + F_n);
        }
    }
}
