using Yorukatsu033.Questions;
using Yorukatsu033.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu033.Questions
{
    /// <summary>
    /// ABC143 E
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nml = inputStream.ReadIntArray();
            var cities = nml[0];
            var roads = nml[1];
            var tankCapacity = nml[2];

            var distances = new long[cities, cities];
            for (int i = 0; i < cities; i++)
            {
                for (int j = 0; j < cities; j++)
                {
                    distances[i, j] = 1L << 60;
                }
            }

            for (int i = 0; i < roads; i++)
            {
                var abc = inputStream.ReadIntArray();
                var a = abc[0] - 1;
                var b = abc[1] - 1;
                var c = abc[2];

                distances[a, b] = c;
                distances[b, a] = c;
            }

            WarshallFloyd(distances);

            var refuelCounts = new long[cities, cities];
            for (int from = 0; from < cities; from++)
            {
                for (int to = 0; to < cities; to++)
                {
                    if (distances[from, to] <= tankCapacity)
                    {
                        refuelCounts[from, to] = 1;
                    }
                    else
                    {
                        refuelCounts[from, to] = 1L << 60;
                    }
                }
            }

            WarshallFloyd(refuelCounts);
            var queries = inputStream.ReadInt();
            for (int i = 0; i < queries; i++)
            {
                var st = inputStream.ReadIntArray().Select(j => j - 1).ToArray();
                var from = st[0];
                var to = st[1];
                var refuelCount = refuelCounts[from, to];
                if (refuelCount < 1L << 60)
                {
                    yield return refuelCount - 1;
                }
                else
                {
                    yield return -1;
                }
            }
        }

        void WarshallFloyd(long[,] graph)
        {
            var n = graph.GetLength(0);
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        graph[i, j] = Math.Min(graph[i, j], graph[i, k] + graph[k, j]);
                    }
                }
            }
        }
    }
}
