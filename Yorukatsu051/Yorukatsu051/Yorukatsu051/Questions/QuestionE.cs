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
    /// https://atcoder.jp/contests/abc051/tasks/abc051_d
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        List<Edge>[] _graph;
        Edge[] _edges;
        bool[] _used;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var nodesCount = nm[0];
            var edgesCount = nm[1];
            _graph = Enumerable.Repeat(0, nodesCount).Select(_ => new List<Edge>()).ToArray();
            _edges = new Edge[edgesCount];

            for (int i = 0; i < edgesCount; i++)
            {
                var abc = inputStream.ReadIntArray();
                var a = abc[0] - 1;
                var b = abc[1] - 1;
                var c = abc[2];
                _graph[a].Add(new Edge(a, b, c, i));
                _graph[b].Add(new Edge(b, a, c, i));
                _edges[i] = new Edge(a, b, c, i);
            }

            _used = new bool[edgesCount];

            for (int i = 0; i < nodesCount; i++)
            {
                var distances = Dijkstra(i);
                foreach (var edge in _edges)
                {
                    if (Math.Abs(distances[edge.From] - distances[edge.To]) == edge.Cost)
                    {
                        _used[edge.ID] = true;
                    }
                }
            }

            yield return _used.Count(b => !b);
        }

        int[] Dijkstra(int start)
        {
            var costs = Enumerable.Repeat(1 << 28, _graph.Length).ToArray();
            costs[start] = 0;

            var todo = new PriorityQueue<State>(false);
            todo.Enqueue(new State(start, 0));

            while (todo.Count > 0)
            {
                var current = todo.Dequeue();
                if (current.Cost > costs[current.Node])
                {
                    continue;
                }

                foreach (var edge in _graph[current.Node])
                {
                    if (costs[edge.To] > current.Cost + edge.Cost)
                    {
                        costs[edge.To] = current.Cost + edge.Cost;
                        todo.Enqueue(new State(edge.To, costs[edge.To]));
                    }
                }
            }

            return costs;
        }

        struct Edge
        {
            public int From { get; }
            public int To { get; }
            public int Cost { get; }
            public int ID { get; }

            public Edge(int from, int to, int cost, int id)
            {
                From = from;
                To = to;
                Cost = cost;
                ID = id;
            }
        }

        struct State : IComparable<State>
        {
            public int Node { get; }
            public int Cost { get; }

            public State(int node, int cost)
            {
                Node = node;
                Cost = cost;
            }

            public int CompareTo(State other) => Cost.CompareTo(other.Cost);
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
