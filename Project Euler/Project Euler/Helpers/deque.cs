using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Euler.Helpers
{
    class deque<T>
    {
        
        private List<T> list;

        public deque()
        {
            list = new List<T>();
        }

        public void push_front(T item)
        {
            list.Insert(0, item);
        }

        public void push_back(T item)
        {
            list.Insert(list.Count, item);
        }

        public T pop_front()
        {
            T item = list[0];
            list.RemoveAt(0);
            return item;
        }

        public T pop_back()
        {
            T item = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return item;
        }

        public T this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                list[index] = value;
            }
        }
    }
}
