using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200828.Algorithms;
using Training20200828.Collections;
using Training20200828.Extensions;
using Training20200828.Numerics;
using Training20200828.Questions;

namespace Training20200828.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (userCount, markedCount, friendshipsCount) = inputStream.ReadValue<int, int, int>();
            var startNode = userCount;
            var endNode = userCount + 1;
            var graph = Enumerable.Repeat(0, userCount + 2).Select(_ => new List<Edge>()).ToArray();

            AddDirectionalEdge(startNode, 0, 1 << 28);

            if (markedCount > 0)
            {
                foreach (var marked in inputStream.ReadIntArray())
                {
                    AddDirectionalEdge(marked, endNode, 1);
                }
            }
            else
            {
                _ = inputStream.ReadLine();
            }

            for (int i = 0; i < friendshipsCount; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                AddNonDirectionalEdge(a, b, 1);
            }

            var used = new bool[graph.Length];

            var flow = 0;
            while (true)
            {
                Array.Clear(used, 0, used.Length);
                var f = Dfs(startNode, 1 << 28);
                if (f == 0)
                {
                    break;
                }
                flow += f;
            }

            yield return flow;

            int Dfs(int current, int flow)
            {
                if (current == endNode)
                {
                    return flow;
                }
                else
                {
                    used[current] = true;
                    foreach (var edge in graph[current])
                    {
                        if (!used[edge.To] && edge.Capacity > 0)
                        {
                            var f = Dfs(edge.To, Math.Min(flow, edge.Capacity));
                            if (f > 0)
                            {
                                edge.Capacity -= f;
                                graph[edge.To][edge.Reverese].Capacity += f;
                                return f;
                            }
                        }
                    }

                    return 0;
                }
            }

            void AddDirectionalEdge(int from, int to, int capacity)
            {
                graph[from].Add(new Edge(to, capacity, graph[to].Count));
                graph[to].Add(new Edge(from, 0, graph[from].Count - 1));
            }

            void AddNonDirectionalEdge(int from, int to, int capacity)
            {
                graph[from].Add(new Edge(to, capacity, graph[to].Count));
                graph[to].Add(new Edge(from, capacity, graph[from].Count - 1));
            }
        }

        class Edge
        {
            public int To { get; }
            public int Capacity { get; set; }
            public int Reverese { get; }

            public Edge(int to, int capacity, int reverse)
            {
                To = to;
                Capacity = capacity;
                Reverese = reverse;
            }

            public override string ToString() => $"{nameof(To)}: {To}, {nameof(Capacity)}: {Capacity}";
        }
    }
}
