using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu072.Algorithms;
using Kujikatsu072.Collections;
using Kujikatsu072.Extensions;
using Kujikatsu072.Numerics;
using Kujikatsu072.Questions;

namespace Kujikatsu072.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc094/tasks/arc094_c
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (height, width) = inputStream.ReadValue<int, int>();
            var canEnter = new bool[height, width];
            var startRow = 0;
            var startColumn = 0;
            var goalRow = 0;
            var goalColumn = 0;

            var graph = Enumerable.Repeat(0, height + width + 2).Select(_ => new List<Edge>()).ToArray();
            var used = new bool[graph.Length];
            const int Inf = 20000;
            const int StartIndex = 0;
            const int GoalIndex = 1;

            for (int row = 0; row < height; row++)
            {
                var s = inputStream.ReadLine();

                for (int column = 0; column < width; column++)
                {
                    if (s[column] != '.')
                    {
                        canEnter[row, column] = true;
                        if (s[column] == 'S')
                        {
                            startRow = row;
                            startColumn = column;
                            AddDirectionalEdge(StartIndex, GetRowIndex(row), Inf);
                            AddDirectionalEdge(StartIndex, GetColumnIndex(column), Inf);
                        }
                        else if (s[column] == 'T')
                        {
                            goalRow = row;
                            goalColumn = column;
                            AddDirectionalEdge(GetRowIndex(row), GoalIndex, Inf);
                            AddDirectionalEdge(GetColumnIndex(column), GoalIndex, Inf);
                        }
                        else
                        {
                            AddNonDirectionalEdge(GetRowIndex(row), GetColumnIndex(column), 1);
                        }
                    }
                }
            }

            if (startRow == goalRow || startColumn == goalColumn)
            {
                yield return -1;
                yield break;
            }

            var flow = 0;
            while (true)
            {
                Array.Clear(used, 0, used.Length);
                var f = Dfs(StartIndex, Inf);
                if (f == 0)
                {
                    break;
                }
                flow += f;
            }

            yield return flow;

            int Dfs(int current, int flow)
            {
                if (current == GoalIndex)
                {
                    return flow;
                }

                used[current] = true;
                for (int i = 0; i < graph[current].Count; i++)
                {
                    var edge = graph[current][i];
                    if (!used[edge.To] && edge.Capacity > 0)
                    {
                        var diff = Dfs(edge.To, Math.Min(flow, edge.Capacity));
                        if (diff > 0)
                        {
                            edge.Capacity -= diff;
                            graph[edge.To][edge.ReverseIndex].Capacity += diff;
                            return diff;
                        }
                    }
                }

                return 0;
            }

            int GetRowIndex(int row) => row + 2;
            int GetColumnIndex(int column) => column + height + 2;

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

        [StructLayout(LayoutKind.Auto)]
        class Edge
        {
            public int To { get; }
            public int Capacity { get; set; }
            public int ReverseIndex { get; }

            public Edge(int to, int capacity, int reverseIndex)
            {
                To = to;
                Capacity = capacity;
                ReverseIndex = reverseIndex;
            }

            public override string ToString() => $"{nameof(To)}: {To}, {nameof(Capacity)}: {Capacity}";
        }
    }
}