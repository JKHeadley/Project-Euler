﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler
{
    /// <summary>
    /// Highly divisible triangular number
    /// 
    /// The sequence of triangle numbers is generated by adding the natural numbers. So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28. The first ten terms would be:
    /// 
    /// 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...
    /// 
    /// Let us list the factors of the first seven triangle numbers:
    /// 
    /// 1: 1
    /// 3: 1,3
    /// 6: 1,2,3,6
    /// 10: 1,2,5,10
    /// 15: 1,3,5,15
    /// 21: 1,3,7,21
    /// 28: 1,2,4,7,14,28
    /// 
    /// We can see that 28 is the first triangle number to have over five divisors.
    /// What is the value of the first triangle number to have over five hundred divisors?
    /// </summary>
    class Problem12
    {
        public void Solve()
        {
            int i = 1, triangle = 0;
            while (true)
            {
                triangle = GetNthTriangleNumber(i);
                var factors = Problem3.FindFactors(triangle);
                Console.WriteLine("Triangle # " + triangle + " has " + factors.Count + " divisors.\n");
                if (factors.Count > 500)
                {
                    Console.WriteLine("The first triangle number with over 500 divisors is " + triangle);
                    return;
                }
                i++;
            }
        }

        int GetNthTriangleNumber(int n)
        {
            int sum = 0;
            for (int i = 1; i <= n; i++)
                sum += i;
            return sum;
        }
    }
}