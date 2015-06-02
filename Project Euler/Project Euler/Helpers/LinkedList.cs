using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler.Helpers
{
    public sealed class Node<T>
    {
        readonly T m_data;
        readonly Node<T> m_prev;
        readonly Node<T> m_next;

        // Data, Next, Prev accessors omitted for brevity      

        public Node(T data, Node<T> prev, IEnumerator<T> rest)
        {
            m_data = data;
            m_prev = prev;
            if (rest.MoveNext())
            {
                m_next = new Node<T>(rest.Current, this, rest);
            }
        }
    }

}
