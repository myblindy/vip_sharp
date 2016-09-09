using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;

namespace vip_sharp
{
    public abstract class BipolarArrayBase
    {
        public int N1 { get; protected set; }
        public int N2 { get; protected set; }
        public int N3 { get; protected set; }
    }

    public class BipolarArray<T> : BipolarArrayBase, IEnumerable<T>, IList<T>
    {
        private T[] Array;
        private bool AutoGrow;

        private int InitIdx = 0;

        int ICollection<T>.Count => Array.Length;

        bool ICollection<T>.IsReadOnly => false;

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

        public static implicit operator T(BipolarArray<T> arr) => arr[0];

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

        public static implicit operator BipolarArray<T>(string s) => new BipolarArray<T>(s);

        public void Set(T val) => Array[0] = val;
        public void Set(int i0, T val) => Array[i0] = val;
        public void Set(int i0, int i1, T val) => this[i0, i1] = val;
        public void Set(int i0, int i1, int i2, T val) => this[i0, i1, i2] = val;

        private void EnumerableCopy(int pos, IEnumerable<T> seq)
        {
            foreach (var item in seq)
                Array[pos++] = item;
        }

        public void Set(IEnumerable<T> seq) => EnumerableCopy(0, seq);
        public void Set(int i0, IEnumerable<T> seq) => EnumerableCopy(i0, seq);
        public void Set(int i0, int i1, IEnumerable<T> seq) => EnumerableCopy(i0 * N1 + i1, seq);
        public void Set(int i0, int i1, int i2, IEnumerable<T> seq) => EnumerableCopy(i0 * N1 + i1 * N2 + i2, seq);

        public void Set(int val) => Array[0] = (T)Convert.ChangeType(val, typeof(T));
        public void Set(int i0, int val) => Array[i0] = (T)Convert.ChangeType(val, typeof(T));
        public void Set(int i0, int i1, int val) => this[i0, i1] = (T)Convert.ChangeType(val, typeof(T));
        public void Set(int i0, int i1, int i2, int val) => this[i0, i1, i2] = (T)Convert.ChangeType(val, typeof(T));

        public T PreIncrement(int i0 = -1, int i1 = -1, int i2 = -1)
        {
            dynamic darr = Array;

            if (i0 == -1) return ++darr[0];
            else if (i1 == -1) return ++darr[i0];
            else if (i2 == -1) return ++darr[i0, i1];
            else return ++darr[i0, i1, i2];
        }

        public T PreDecrement(int i0 = -1, int i1 = -1, int i2 = -1)
        {
            dynamic darr = Array;

            if (i0 == -1) return --darr[0];
            else if (i1 == -1) return --darr[i0];
            else if (i2 == -1) return --darr[i0, i1];
            else return --darr[i0, i1, i2];
        }

        public T PostIncrement(int i0 = -1, int i1 = -1, int i2 = -1)
        {
            dynamic darr = Array;

            if (i0 == -1) return darr[0]++;
            else if (i1 == -1) return darr[i0]++;
            else if (i2 == -1) return darr[i0, i1]++;
            else return darr[i0, i1, i2]++;
        }

        public T PostDecrement(int i0 = -1, int i1 = -1, int i2 = -1)
        {
            dynamic darr = Array;

            if (i0 == -1) return darr[0]--;
            else if (i1 == -1) return darr[i0]--;
            else if (i2 == -1) return darr[i0, i1]--;
            else return darr[i0, i1, i2]--;
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

        int IList<T>.IndexOf(T item) { throw new NotImplementedException(); }

        void IList<T>.Insert(int index, T item) { throw new NotImplementedException(); }

        void IList<T>.RemoveAt(int index) { throw new NotImplementedException(); }

        void ICollection<T>.Clear() { throw new NotImplementedException(); }

        bool ICollection<T>.Contains(T item) => Array.Contains(item);

        void ICollection<T>.CopyTo(T[] array, int arrayIndex) => Array.CopyTo(array, arrayIndex);

        bool ICollection<T>.Remove(T item) { throw new NotImplementedException(); }

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
