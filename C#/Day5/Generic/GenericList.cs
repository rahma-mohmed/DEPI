using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    public class GenericList<T> 
    {
        private List<T> list= new List<T>();

        public void Add(T item)
        { 
            list.Add(item);
        }
        public void Clear()
        {
            list.Clear();
        }
        public T GetByIndex(int ind)
        {
            if (ind > list.Count-1)
            {
                return default(T);
            }
            return list[ind];
        }
        public void Display()
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        public T this[int index]{
            get
            {
                return this.list[index];
            }
            set
            {
                this.list[index] = value;
            }
        }
    }
}
