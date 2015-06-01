using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler.Helpers
{
    class BigNum
    {
        private char sign;
        private int length;
        private deque<int> digits;
        private deque<int> postdec;

        public BigNum()
        {
            digits = new deque<int>();
            postdec = new deque<int>();
            sign = 'p';
            length = 10000;
        }
    }
}
