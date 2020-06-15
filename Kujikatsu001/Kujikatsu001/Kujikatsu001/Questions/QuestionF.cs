using Kujikatsu001.Questions;
using Kujikatsu001.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Kujikatsu001.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc098/tasks/arc098_c
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nkq = inputStream.ReadIntArray();
            var n = nkq[0];
            var neededWidth = nkq[1];
            var queries = nkq[2];
            var a = inputStream.ReadIntArray();

            var min = int.MaxValue;

            foreach (var minToRemove in a.Distinct())
            {
                min = Math.Min(min, GetDiff(a, minToRemove, queries, neededWidth));
            }

            yield return min;
        }

        int GetDiff(int[] a, int minToRemove, int queries, int neededWidth)
        {
            var queue = new PriorityQueue<int>(false);
            var toRemoves = new List<int>();

            foreach (var ai in a)
            {
                if (ai >= minToRemove)
                {
                    queue.Enqueue(ai);
                    if (queue.Count >= neededWidth)
                    {
                        toRemoves.Add(queue.Dequeue());
                    }
                }
                else
                {
                    queue = new PriorityQueue<int>(false);
                }
            }

            toRemoves.Sort();

            if (toRemoves.Count >= queries)
            {
                var min = toRemoves[0];
                var max = toRemoves[queries - 1];
                return max - min;
            }
            else
            {
                return int.MaxValue;
            }
        }

        public class PriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
        {
            private List<T> _heap = new List<T>();
            private readonly int _reverseFactor;
            public int Count => _heap.Count;
            public bool IsDescending => _reverseFactor == 1;

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

            public T Peek() => _heap[0];

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

            private int Compare(T a, T b) => _reverseFactor * a.CompareTo(b);

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

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
        }

    }
}
