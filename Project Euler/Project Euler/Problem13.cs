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
            BigNum e = new BigNum(0, 100), n = new BigNum(0, 100), stop = new BigNum();//finding e
            for (; true; ++n)
            {
                e = e + (1 / n.factorial());
                if (stop == e)
                    break;
                stop = e;
                Console.WriteLine((int)e);
            }
            Console.WriteLine((int)e);
        }
    }
}
