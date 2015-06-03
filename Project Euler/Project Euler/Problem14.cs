using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Euler.Helpers;
using System.IO;

namespace Project_Euler
{
    /// <summary>
    /// Longest Collatz sequence
    /// 
    /// The following iterative sequence is defined for the set of positive integers:
    /// 
    /// n → n/2 (n is even)
    /// n → 3n + 1 (n is odd)
    /// 
    /// Using the rule above and starting with 13, we generate the following sequence:
    /// 
    /// 13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
    /// 
    /// It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), 
    /// it is thought that all starting numbers finish at 1.
    /// 
    /// Which starting number, under one million, produces the longest chain?
    /// 
    /// NOTE: Once the chain starts the terms are allowed to go above one million.
    /// </summary>
    class Problem14
    {
        public void Solve()
        {
            int size = 1000000;
            Dictionary<int, int> collatzSizes = new Dictionary<int, int>();
            List<List<int>> sequences = new List<List<int>>();
            StreamWriter writer = new StreamWriter("../../Text Files/Problem14output.txt");
            for(int i = size, j = 0; i > 0; i--, j++)
            {
                //sequences.Add(Methods.GetCollatz(i));
                collatzSizes.Add(i, Methods.GetCollatzSize(i));
                //writer.WriteLine(i + "\t" + sequences[j].Count);
            }
            writer.Close();

            //List<KeyValuePair<int, int>> myList = collatzSizes.ToList();

            //myList.Sort((firstPair, nextPair) =>
            //{
            //    //return firstPair.Value.CompareTo(nextPair.Value);
            //    if (firstPair.Value > nextPair.Value)
            //        return firstPair.Value;
            //    else
            //        return nextPair.Value;
            //}
            //);

            var sortedSizes = from entry in collatzSizes orderby entry.Value descending select entry;

            Console.WriteLine("Number under " + size + " that has the largest Collatz sequence is: " + sortedSizes.First().Key);
        }
    }
}
