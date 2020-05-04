using Yorukatsu031.Questions;
using Yorukatsu031.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu031.Questions
{
    /// <summary>
    /// ABC128 D
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadIntArray();
            var jewelCount = nk[0];
            var operationCount = nk[1];
            var jewels = inputStream.ReadIntArray();
            var maxDequeueCount = Math.Min(jewelCount, operationCount);

            var max = 0;
            for (int left = 0; left <= maxDequeueCount; left++)
            {
                for (int right = 0; left + right <= maxDequeueCount; right++)
                {
                    var aquiredJewels = new PriorityQueue<int>(false);
                    foreach (var jewel in jewels.Take(left))
                    {
                        aquiredJewels.Enqueue(jewel);
                    }
                    foreach (var jewel in jewels.Reverse().Take(right))
                    {
                        aquiredJewels.Enqueue(jewel);
                    }

                    var op = operationCount - (left + right);
                    for (int i = 0; i < op; i++)
                    {
                        if (aquiredJewels.Any() && aquiredJewels.Peek() < 0)
                        {
                            aquiredJewels.Dequeue();
                        }
                        else
                        {
                            break;
                        }
                    }

                    max = Math.Max(max, aquiredJewels.Sum());
                }
            }

            yield return max;
        }

        public class PriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
        {
            private List<T> _heap = new List<T>();
            private readonly int _reverseFactor;
            public int Count => _heap.Count;
            public bool IsDescending => _reverseFactor == 1;

            public PriorityQueue() : this(null, true) { }

            public PriorityQueue(IEnumerable<T> collection) : this(collection, true) { }

            public PriorityQueue(bool descending) : this(null, descending) { }

            public PriorityQueue(IEnumerable<T> collection, bool descending)
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
