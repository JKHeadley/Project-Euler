﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Euler.Helpers;

namespace Project_Euler
{
    /// <summary>
    /// 10001st prime
    /// 
    /// Summation of primes
    /// 
    /// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
    /// What is the 10,001st prime number?
    /// </summary>
    class Problem7
    {
        public void Solve()
        {
            int i = 2;
            List<int> primes = new List<int>();
            while (primes.Count < 10001)
            {
                if (Methods.IsPrime(i))
                {
                    primes.Add(i);
                    //Console.WriteLine(primes.Last() + " is the " + primes.Count + " prime number.\n");
                }
                i++;
            }
            Console.WriteLine(primes.Last() + " is the " + primes.Count + " prime number.\n");
            Console.WriteLine("The correct solution is : " + 104743);
        }
    }
}
