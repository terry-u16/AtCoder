using AtCoderBeginnerContest116.Questions;
using AtCoderBeginnerContest116.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest116.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadIntArray();
            var sushis = new Sushi[nk[0]];
            var canEat = nk[1];

            for (int i = 0; i < sushis.Length; i++)
            {
                var td = inputStream.ReadIntArray();
                sushis[i] = new Sushi(td[0], td[1]);
            }

            Array.Sort(sushis);
            Array.Reverse(sushis);

            var eatenSushiTypes = new HashSet<long>();
            var duplicatedSushis = new PriorityQueue<Sushi>(false);
            long sum = 0;
            foreach (var sushi in sushis.Take(canEat))
            {
                sum += sushi.Deliciousness;
                if (!eatenSushiTypes.Add(sushi.Type))
                {
                    duplicatedSushis.Enqueue(sushi);
                }
            }

            var valiousSushis = new Queue<Sushi>(sushis.Skip(canEat)
                                                       .Where(s => !eatenSushiTypes.Contains(s.Type))
                                                       .GroupBy(s => s.Type, (t, s) => s.First()))
                                                       .ToArray();

            var points = new long[Math.Min(valiousSushis.Length, duplicatedSushis.Count) + 1];
            points[0] = sum + (long)eatenSushiTypes.Count * eatenSushiTypes.Count;

            for (int i = 1; i < points.Length; i++)
            {
                var sushi = valiousSushis[i - 1];
                var duplicatedSushi = duplicatedSushis.Dequeue();
                long diff = sushi.Deliciousness - duplicatedSushi.Deliciousness;
                long variety = eatenSushiTypes.Count;
                points[i] = points[i - 1] + diff + (variety + 1) * (variety + 1) - (variety * variety);
                eatenSushiTypes.Add(sushi.Type);
            }

            yield return points.Max();
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


        struct Sushi : IComparable<Sushi>
        {
            public long Type { get; }
            public long Deliciousness { get; }

            public Sushi(long type, long deliciousness)
            {
                Type = type;
                Deliciousness = deliciousness;
            }

            public override string ToString() => $"Type:{Type}, Deliciousness:{Deliciousness}";

            public int CompareTo(Sushi other)
            {
                var compared = Deliciousness.CompareTo(other.Deliciousness);
                if (compared != 0)
                {
                    return compared;
                }
                return Type.CompareTo(other.Type);
            }
        }
    }
}
