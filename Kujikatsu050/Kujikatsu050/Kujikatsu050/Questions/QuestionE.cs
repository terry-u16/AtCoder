using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu050.Algorithms;
using Kujikatsu050.Collections;
using Kujikatsu050.Extensions;
using Kujikatsu050.Numerics;
using Kujikatsu050.Questions;

namespace Kujikatsu050.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc039/tasks/agc039_b
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        bool[][] graph;
        Color[] colors;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            const int Inf = 1 << 25;
            var n = inputStream.ReadInt();
            graph = new bool[n][];
            colors = new Color[n];
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = inputStream.ReadString().Select(c => c == '1').ToArray();
            }

            if (Paint(0, Color.Black))
            {
                int[][] distances = GetDistanceMatrix(Inf, n);
                WarshallFloyd(n, distances);
                yield return distances.Max(d => d.Max()) + 1;
            }
            else
            {
                yield return -1;
            }
        }

        private static void WarshallFloyd(int n, int[][] distances)
        {
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        distances[i][j] = Math.Min(distances[i][j], distances[i][k] + distances[k][j]);
                    }
                }
            }
        }

        private int[][] GetDistanceMatrix(int Inf, int n)
        {
            var distances = new int[n][];
            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = new int[n];
                for (int j = 0; j < distances[i].Length; j++)
                {
                    if (i == j)
                    {
                        distances[i][j] = 0;
                    }
                    else if (graph[i][j])
                    {
                        distances[i][j] = 1;
                    }
                    else
                    {
                        distances[i][j] = Inf;
                    }
                }
            }

            return distances;
        }

        bool Paint(int current, Color color)
        {
            colors[current] = color;
            var adjacents = graph[current];
            for (int next = 0; next < adjacents.Length; next++)
            {
                if (adjacents[next])
                {
                    if ((colors[next] == Color.None && !Paint(next, color == Color.Black ? Color.White : Color.Black)) 
                        || colors[next] == color)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        enum Color
        {
            None,
            Black,
            White
        }
    }
}
