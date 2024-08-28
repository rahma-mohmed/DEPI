using System.Collections;

namespace Enumerable
{
    public class MyCollection : IEnumerable<int>
    {
        private List<int> list = new List<int>();

        public void Add(int item)
        {
            list.Add(item); 
        }

        public IEnumerator<int> GetEnumerator()
        {
            //return new MyEnumerator(list);

            foreach (var item in list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class MyEnumerator : IEnumerator<int>
    {
        private List<int> _list;
        private int _index;

        public MyEnumerator(List<int> list)
        {
            _list = list;
        }

        public int Current => _list[_index];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            _index++;
            return _index < _list.Count();
        }

        public void Reset()
        {
            _index = -1;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
