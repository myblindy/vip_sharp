using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vip_sharp
{
    public class BipolarArray<T> : IEnumerable<T>
    {
        private T[] Array;
        public int N1 { get; private set; }
        public int N2 { get; private set; }
        public int N3 { get; private set; }

        private int InitIdx = 0;

        public BipolarArray(string init)
        {
            Array = new T[init.Length + 1];             // null character
            for (int i = 0; i < init.Length; ++i)
                ((dynamic)Array)[i] = init[i];
        }
        public BipolarArray(int n1, string init = null) : this(n1, 1, 1, init) { }
        public BipolarArray(int n1, int n2, string init = null) : this(n1, n2, 1, init) { }
        public BipolarArray(int n1, int n2, int n3, string init = null)
        {
            Array = new T[n1 * n2 * n3];
            N1 = n1; N2 = n2; N3 = n3;
            if (init != null)
                for (int i = 0; i < init.Length; ++i)
                    ((dynamic)Array)[i] = init[i];
        }

        public T this[int n]
        {
            get { return Array[n]; }
            set { Array[n] = value; }
        }

        public T this[int n1, int n2]
        {
            get { return Array[n1 * N1 + n2]; }
            set { Array[n1 * N1 + n2] = value; }
        }

        public T this[int n1, int n2, int n3]
        {
            get { return Array[n1 * N1 + n2 * N2 + n3]; }
            set { Array[n1 * N1 + n2 * N2 + n3] = value; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var val in Array)
                yield return val;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(T val) => Array[InitIdx++] = val;
    }
}
