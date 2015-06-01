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
            int[] array = new int[20];
            List<int> list = new List<int>();
            list.Add(1);
            list.Insert(list.Count, 2);
            list.Insert(0, 3);
            list.RemoveAt(list.Count-1);
            list.RemoveAt(0);

            deque<int> deq = new deque<int>();
            deq.push_front(1);
            deq.push_back(2);
            deq.push_front(3);
            deq.pop_back();
            deq.pop_front();
        }
    }
}
