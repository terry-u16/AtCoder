using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ACPC2020Day3.Extensions;
using ACPC2020Day3.Questions;
using System.Diagnostics.CodeAnalysis;

namespace ACPC2020Day3.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var n = nm[0];
            var m = nm[1];

            var a = inputStream.ReadIntArray();
            var b = inputStream.ReadIntArray();

            var queue = new PriorityQueue<ValueAndIndex>(true);

            for (int i = 0; i < b.Length; i++)
            {
                queue.Enqueue(new ValueAndIndex(b[i], i));
            }

            foreach (var ai in a)
            {
                while (queue.Peek().Value >= ai)
                {
                    var current = queue.Dequeue();
                    queue.Enqueue(current.TakeMod(ai));
                }
            }

            var result = new int[b.Length];

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                result[current.Index] = current.Value;
            }

            yield return result.Join(" ");
        }

        struct ValueAndIndex : IComparable<ValueAndIndex>
        {
            public readonly int Value;
            public readonly int Index;

            public ValueAndIndex(int value, int index)
            {
                Value = value;
                Index = index;
            }

            public int CompareTo(ValueAndIndex other)
            {
                return Value - other.Value;
            }

            public ValueAndIndex TakeMod(int n)
            {
                return new ValueAndIndex(Value % n, Index);
            }

            public override string ToString()
            {
                return Value.ToString();
            }
        }

        public class PriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
        {
            private List<T> _heap = new List<T>();
            private readonly int _reverseFactor;

            public int Count
            {
                get
                {
                    return _heap.Count;
                }
            }

            public bool IsDescending
            {
                get
                {
                    return _reverseFactor == 1;
                }
            }

            public PriorityQueue(bool descending) : this(descending, null) { }

            public PriorityQueue(bool descending, IEnumerable<T> collection)
            {
                _reverseFactor = descending ? 1 : -1;
                _heap = new List<T>();

                if (collection != null)
                {
                    foreach (var item in collection)
                    {
                        Enqueue(item);
                    }
                }
            }

            public void Enqueue(T item)
            {
                _heap.Add(item);
                UpHeap();
            }

            public T Dequeue()
            {
                var item = _heap[0];
                DownHeap();
                return item;
            }

            public T Peek()
            {
                return _heap[0];
            }

            private void UpHeap()
            {
                var child = Count - 1;
                while (child > 0)
                {
                    int parent = (child - 1) / 2;

                    if (Compare(_heap[child], _heap[parent]) > 0)
                    {
                        SwapAt(child, parent);
                        child = parent;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            private void DownHeap()
            {
                _heap[0] = _heap[Count - 1];
                _heap.RemoveAt(Count - 1);

                var parent = 0;
                while (true)
                {
                    var leftChild = 2 * parent + 1;

                    if (leftChild > Count - 1)
                    {
                        break;
                    }

                    var target = (leftChild < Count - 1) && (Compare(_heap[leftChild], _heap[leftChild + 1]) < 0) ? leftChild + 1 : leftChild;

                    if (Compare(_heap[parent], _heap[target]) < 0)
                    {
                        SwapAt(parent, target);
                    }
                    else
                    {
                        break;
                    }

                    parent = target;
                }
            }

            private int Compare(T a, T b)
            {
                return _reverseFactor * a.CompareTo(b);
            }

            private void SwapAt(int n, int m)
            {
                var temp = _heap[n];
                _heap[n] = _heap[m];
                _heap[m] = temp;
            }

            public IEnumerator<T> GetEnumerator()
            {
                var copy = new List<T>(_heap);
                try
                {
                    while (Count > 0)
                    {
                        yield return Dequeue();
                    }
                }
                finally
                {
                    _heap = copy;
                }
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

    }
}
