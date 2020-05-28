using Training20200528.Questions;
using Training20200528.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200528.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/code-festival-2016-qualb/tasks/codefestival_2016_qualB_c
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var wh = inputStream.ReadIntArray();
            var width = wh[0];
            var height = wh[1];

            var queue = new PriorityQueue<Edge>(false);

            for (int i = 0; i < width; i++)
            {
                queue.Enqueue(new Edge(Direction.X, inputStream.ReadLong()));
            }

            for (int i = 0; i < height; i++)
            {
                queue.Enqueue(new Edge(Direction.Y, inputStream.ReadLong()));
            }

            long sum = 0;
            var horizontal = height + 1;
            var vertical = width + 1;
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current.Direction == Direction.X)
                {
                    sum += horizontal * current.Cost;
                    vertical--;
                }
                else
                {
                    sum += vertical * current.Cost;
                    horizontal--;
                }
            }

            yield return sum;
        }

        struct Edge : IComparable<Edge>
        {
            public Direction Direction { get; }
            public long Cost { get; }

            public Edge(Direction direction, long cost)
            {
                Direction = direction;
                Cost = cost;
            }

            public int CompareTo(Edge other) => Cost.CompareTo(other.Cost);
        }

        enum Direction
        {
            X,
            Y
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
