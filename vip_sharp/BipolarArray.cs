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
        private bool AutoGrow;
        public int N1 { get; private set; }
        public int N2 { get; private set; }
        public int N3 { get; private set; }

        private int InitIdx = 0;

        public BipolarArray()
        {
            Array = new T[0];
            AutoGrow = true;
        }
        public BipolarArray(string init)
        {
            Array = new T[init.Length + 1];             // null character

            var arr = (char[])(object)Array;

            for (int i = 0; i < init.Length; ++i)
                arr[i] = init[i];
        }
        public BipolarArray(int n1, string init = null) : this(n1, 1, 1, init) { }
        public BipolarArray(int n1, int n2, string init = null) : this(n1, n2, 1, init) { }
        public BipolarArray(int n1, int n2, int n3, string init = null)
        {
            Array = new T[n1 * n2 * n3];
            N1 = n1; N2 = n2; N3 = n3;
            if (init != null)
            {
                var arr = (char[])(object)Array;

                for (int i = 0; i < init.Length; ++i)
                    arr[i] = init[i];
            }
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

        public void Add(T val)
        {
            if (AutoGrow && InitIdx >= Array.Length)
                System.Array.Resize(ref Array, Array.Length + 1);
            Array[InitIdx++] = val;
        }

        public void Set(string s)
        {
            var arr = (char[])(object)Array;

            for (int i = 0; i < s.Length; ++i)
                arr[i] = s[i];
            arr[s.Length] = (char)0;
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
                if (obj is string)
                    return this == (string)obj;
                else if (obj is BipolarArray<T>)
                    return Array.SequenceEqual(((BipolarArray<T>)obj).Array);

            return base.Equals(obj);
        }

        public override int GetHashCode() => Array.GetHashCode();

        public static bool operator ==(BipolarArray<T> _ba, string s)
        {
            if ((ReferenceEquals(s, null) || ReferenceEquals(_ba, null)) && !ReferenceEquals(s, _ba)) return false;
            var ba = (object)_ba as BipolarArray<char>;
            if (ReferenceEquals(ba, null)) return false;

            int i;
            var slen = s.Length;
            var arrlen = ba.Array.Length;
            for (i = 0; i < slen; ++i)
                if (i >= arrlen || s[i] != ba[i])
                    return false;

            return ba[i] == 0;
        }

        public static bool operator !=(BipolarArray<T> _ba, string s) => !(_ba == s);
    }
}
