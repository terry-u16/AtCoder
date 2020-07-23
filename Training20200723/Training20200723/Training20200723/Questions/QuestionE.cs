using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200723.Algorithms;
using Training20200723.Collections;
using Training20200723.Extensions;
using Training20200723.Numerics;
using Training20200723.Questions;

namespace Training20200723.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc035/tasks/arc035_c
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (cities, roads) = inputStream.ReadValue<int, int>();
            const int Inf = int.MaxValue >> 1;
            var distances = Enumerable.Repeat(0, cities).Select(_ => new int[cities]).ToArray();

            for (int i = 0; i < distances.Length; i++)
            {
                for (int j = 0; j < distances[i].Length; j++)
                {
                    if (i != j)
                    {
                        distances[i][j] = Inf;
                    }
                }
            }

            for (int i = 0; i < roads; i++)
            {
                var (from, to, distance) = inputStream.ReadValue<int, int, int>();
                from--;
                to--;
                distances[from][to] = distance;
                distances[to][from] = distance;
            }

            WarshallFloyd(distances);

            var construction = inputStream.ReadInt();
            for (int i = 0; i < construction; i++)
            {
                var (from, to, distance) = inputStream.ReadValue<int, int, int>();
                from--;
                to--;
                Update(distances, from, to, distance);
                yield return GetSum(distances);
            }
        }

        void WarshallFloyd(int[][] distances)
        {
            for (int k = 0; k < distances.Length; k++)
            {
                for (int i = 0; i < distances.Length; i++)
                {
                    for (int j = 0; j < distances[i].Length; j++)
                    {
                        AlgorithmHelpers.UpdateWhenSmall(ref distances[i][j], distances[i][k] + distances[k][j]);
                    }
                }
            }
        }

        void Update(int[][] distances, int from, int to, int d)
        {
            for (int i = 0; i < distances.Length; i++)
            {
                for (int j = 0; j < distances[i].Length; j++)
                {
                    AlgorithmHelpers.UpdateWhenSmall(ref distances[i][j], distances[i][from] + d + distances[to][j]);
                    AlgorithmHelpers.UpdateWhenSmall(ref distances[i][j], distances[i][to] + d + distances[from][j]);
                }
            }
        }

        long GetSum(int[][] distances)
        {
            long sum = 0;
            for (int from = 0; from < distances.Length; from++)
            {
                for (int to = from + 1; to < distances[from].Length; to++)
                {
                    sum += distances[from][to];
                }
            }
            return sum;
        }
    }
}
