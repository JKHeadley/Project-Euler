﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler
{
    class Problem1
    {
        public void Solve()
        {
            List<int> multiplesOf3 = MultiplesBelow(3,10);
            List<int> multiplesOf5 = MultiplesBelow(5,10);

            var multiples = new HashSet<int>(multiplesOf3.Concat(multiplesOf5).ToList()).ToList();
            multiples.Sort();

            Console.WriteLine("Multiples of 3 or 5 under 10: ");

            Console.WriteLine(string.Join(",", multiples.ToArray()));

            Console.WriteLine("Sum: " + multiples.Sum());


            multiplesOf3 = MultiplesBelow(3, 1000);
            multiplesOf5 = MultiplesBelow(5, 1000);

            multiples = new HashSet<int>(multiplesOf3.Concat(multiplesOf5).ToList()).ToList();
            multiples.Sort();

            Console.WriteLine("Multiples of 3 or 5 under 1000: ");

            Console.WriteLine(string.Join(",", multiples.ToArray()));

            Console.WriteLine("Sum: " + multiples.Sum());
        }

        List<int> MultiplesBelow(int mulitple, int size)
        {
            List<int> multiples = new List<int>();
            for (int i = 0; i < size; i++)
            {
                if (i % mulitple == 0)
                    multiples.Add(i);
            }
            return multiples;
        }
    }
}
