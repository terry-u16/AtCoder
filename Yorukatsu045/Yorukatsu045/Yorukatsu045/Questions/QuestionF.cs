using Yorukatsu045.Questions;
using Yorukatsu045.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu045.Questions
{
    /// <summary>
    /// ARC064 E
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var startAndEnd = inputStream.ReadIntArray();
            var barrierCount = inputStream.ReadInt();
            var barriers = new Barrier[barrierCount + 2];
            barriers[0] = new Barrier(startAndEnd[0], startAndEnd[1], 0);
            for (int i = 0; i < barrierCount; i++)
            {
                var xyr = inputStream.ReadIntArray();
                barriers[i + 1] = new Barrier(xyr[0], xyr[1], xyr[2]);
            }
            barriers[barriers.Length - 1] = new Barrier(startAndEnd[2], startAndEnd[3], 0);

            var edges = Enumerable.Repeat(0, barriers.Length).Select(_ => new List<Edge>()).ToArray();

            for (int i = 0; i < edges.Length - 1; i++)
            {
                for (int j = i + 1; j < edges.Length; j++)
                {
                    var distance = barriers[i].GetCosmicDistanceTo(barriers[j]);
                    edges[i].Add(new Edge(j, distance));
                    edges[j].Add(new Edge(i, distance));
                }
            }

            var minDistances = GetMinDistanceFrom(0, edges);

            yield return minDistances[minDistances.Length - 1];
        }

        double[] GetMinDistanceFrom(int start, List<Edge>[] edges)
        {
            var distances = Enumerable.Repeat(1e20, edges.Length).ToArray();

            var queue = new PriorityQueue<DPState>(false);
            queue.Enqueue(new DPState(start, 0));

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.TotalDistance > distances[current.Point])
                {
                    continue;
                }

                foreach (var edge in edges[current.Point])
                {
                    var currentDistance = current.TotalDistance + edge.CosmicDistance;
                    if (distances[edge.To] > currentDistance)
                    {
                        distances[edge.To] = currentDistance;
                        queue.Enqueue(new DPState(edge.To, currentDistance));
                    }
                }
            }

            return distances;   
        }

        struct Edge
        {
            public int To { get; }
            public double CosmicDistance { get; }

            public Edge(int to, double cosmicDistance)
            {
                To = to;
                CosmicDistance = cosmicDistance;
            }

            public override string ToString() => $"--{CosmicDistance:0.00}-->{To}";
        }

        struct DPState : IComparable<DPState>
        {
            public int Point { get; }
            public double TotalDistance { get; }

            public DPState(int point, double totalDistance)
            {
                Point = point;
                TotalDistance = totalDistance;
            }

            public int CompareTo(DPState other) => TotalDistance.CompareTo(other.TotalDistance);
        }

        struct Barrier
        {
            public double X { get; }
            public double Y { get; }
            public double R { get; }

            public Barrier(double x, double y, double r)
            {
                X = x;
                Y = y;
                R = r;
            }

            public double GetCosmicDistanceTo(Barrier other) => Math.Max(Math.Sqrt((X - other.X) * (X - other.X) + (Y - other.Y) * (Y - other.Y)) - (R + other.R), 0);
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
