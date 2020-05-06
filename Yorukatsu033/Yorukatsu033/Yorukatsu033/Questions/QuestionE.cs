using Yorukatsu033.Questions;
using Yorukatsu033.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu033.Questions
{
    /// <summary>
    /// ABC106 D
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nmq = inputStream.ReadIntArray();
            var cities = nmq[0];
            var trains = nmq[1];
            var queries = nmq[2];

            var coveredTrains = new int[cities, cities];    // [begin, end]

            for (int train = 0; train < trains; train++)
            {
                var lr = inputStream.ReadIntArray().Select(i => i - 1).ToArray();
                coveredTrains[lr[0], lr[1]]++;
            }

            // 横方向への累積和
            for (int start = 0; start < cities; start++)
            {
                for (int end = 1; end < cities; end++)
                {
                    coveredTrains[start, end] += coveredTrains[start, end - 1];
                }
            }

            // 縦方向への累積和
            for (int end = 0; end < cities; end++)
            {
                for (int start = cities - 2; start >= 0; start--)
                {
                    coveredTrains[start, end] += coveredTrains[start + 1, end];
                }
            }

            for (int query = 0; query < queries; query++)
            {
                var pq = inputStream.ReadIntArray().Select(i => i - 1).ToArray();
                yield return coveredTrains[pq[0], pq[1]];
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
                var temp = _heap[m];
                _heap[m] = _heap[n];
                _heap[n] = temp;
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
