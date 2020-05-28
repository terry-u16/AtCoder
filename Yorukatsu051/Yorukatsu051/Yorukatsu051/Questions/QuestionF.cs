using Yorukatsu051.Questions;
using Yorukatsu051.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu051.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc116/tasks/abc116_d
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadIntArray();
            var sushiCount = nk[0];
            var toEatCount = nk[1];

            var sushis = new PriorityQueue<Sushi>(true);

            for (int i = 0; i < sushiCount; i++)
            {
                var td = inputStream.ReadIntArray();
                sushis.Enqueue(new Sushi(td[0], td[1]));
            }

            var bestSushis = new Dictionary<int, Sushi>();
            var duplicated = new PriorityQueue<Sushi>(false);
            long maxPoint = 0;
            for (int i = 0; i < toEatCount; i++)
            {
                var sushi = sushis.Dequeue();
                maxPoint += sushi.Deliciousness;
                if (bestSushis.ContainsKey(sushi.Type))
                {
                    if (bestSushis[sushi.Type].CompareTo(sushi) >= 0)
                    {
                        duplicated.Enqueue(sushi);
                    }
                    else
                    {
                        duplicated.Enqueue(bestSushis[sushi.Type]);
                        bestSushis[sushi.Type] = sushi;
                    }
                }
                else
                {
                    bestSushis[sushi.Type] = sushi;
                }
            }

            maxPoint += (long)bestSushis.Count * bestSushis.Count;
            var point = maxPoint;
            while (sushis.Count > 0 && duplicated.Count > 0)
            {
                var sushi = sushis.Dequeue();
                if (bestSushis.ContainsKey(sushi.Type))
                {
                    continue;
                }

                point += sushi.Deliciousness;
                point -= duplicated.Dequeue().Deliciousness;
                long variety = bestSushis.Count;
                point += (variety + 1) * (variety + 1) - variety * variety;
                bestSushis[sushi.Type] = sushi;
                if (point > maxPoint)
                {
                    maxPoint = point;
                }
            }

            yield return maxPoint;
        }

        struct Sushi : IComparable<Sushi>
        {
            public int Type { get; }
            public long Deliciousness { get; }

            public Sushi(int type, long deliciousness)
            {
                Type = type;
                Deliciousness = deliciousness;
            }

            public int CompareTo(Sushi other) => Deliciousness.CompareTo(other.Deliciousness);
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
