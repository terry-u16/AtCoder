using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu029.Algorithms;
using Kujikatsu029.Collections;
using Kujikatsu029.Extensions;
using Kujikatsu029.Numerics;
using Kujikatsu029.Questions;
using Kujikatsu029.Graphs;

namespace Kujikatsu029.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc063/tasks/arc063_c
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        BasicGraph graph;
        int[] maxValues;
        int[] minValues;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            maxValues = Enumerable.Repeat(int.MaxValue, n).ToArray();
            minValues = Enumerable.Repeat(int.MinValue, n).ToArray();

            graph = new BasicGraph(n);
            for (int i = 0; i < n - 1; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                a--;
                b--;
                graph.AddEdge(new BasicEdge(a, b));
                graph.AddEdge(new BasicEdge(b, a));
            }

            var starts = new List<int>();
            var k = inputStream.ReadInt();
            for (int i = 0; i < k; i++)
            {
                var (v, p) = inputStream.ReadValue<int, int>();
                v--;
                maxValues[v] = p;
                minValues[v] = p;
                starts.Add(v);
            }

            if (!CheckEvenOdd(starts[0], -1, minValues[starts[0]]))
            {
                yield return "No";
                yield break;
            }

            //Shuffle(starts);

            foreach (var start in starts)
            {
                Dfs(start, -1, maxValues[start] + 1, minValues[start] - 1);
            }

            for (int i = 0; i < maxValues.Length; i++)
            {
                if (maxValues[i] < minValues[i])
                {
                    yield return "No";
                    yield break;
                }
            }

            yield return "Yes";
            foreach (var value in minValues)
            {
                yield return value;
            }
        }

        bool CheckEvenOdd(int current, int parent, int parity)
        {
            var ok = minValues[current] == int.MinValue || (minValues[current] % 2 == parity % 2);
            foreach (var edge in graph[current])
            {
                var to = edge.To.Index;
                if (to == parent)
                {
                    continue;
                }

                ok &= CheckEvenOdd(to, current, parity + 1);
            }
            return ok;
        }

        void Dfs(int current, int parent, int max, int min)
        {
            foreach (var edge in graph[current])
            {
                var to = edge.To.Index;
                if (to == parent)
                {
                    continue;
                }

                var maxUpdated = false;
                var minUpdated = false;
                if (max < maxValues[to])
                {
                    maxValues[to] = max;
                    maxUpdated = true;
                }

                if (min > minValues[to])
                {
                    minValues[to] = min;
                    minUpdated = true;
                }

                if (maxUpdated || minUpdated)
                {
                    Dfs(to, current, max + 1, min - 1);
                }
            }
        }

        void Shuffle(List<int> list)
        {
            var random = new Random();
            var i = list.Count;
            while (i > 1)
            {
                i--;
                var j = random.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }
    }
}
