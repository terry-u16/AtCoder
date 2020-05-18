using Yorukatsu042.Questions;
using Yorukatsu042.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu042.Questions
{
    /// <summary>
    /// ABC074 D
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var cities = inputStream.ReadInt();
            var map = new long[cities, cities];
            var roads = new long[cities, cities];

            for (int i = 0; i < cities; i++)
            {
                var row = inputStream.ReadLongArray();
                for (int j = 0; j < row.Length; j++)
                {
                    map[i, j] = row[j];
                }
            }

            Array.Copy(map, roads, map.Length);

            const long Inf = 1L << 50;

            for (int k = 0; k < cities; k++)
            {
                for (int i = 0; i < cities; i++)
                {
                    for (int j = 0; j < cities; j++)
                    {
                        if (i == j || j == k || k == i || roads[i, k] == Inf || roads[k, j] == Inf)
                        {
                            continue;
                        }
                        else if (map[i, j] > roads[i, k] + roads[k, j])
                        {
                            yield return -1;
                            yield break;
                        }
                        else if (map[i, j] == roads[i, k] + roads[k, j])
                        {
                            roads[i, j] = Inf;
                        }
                    }
                }
            }

            long totalDistances = 0;
            for (int i = 0; i < cities; i++)
            {
                for (int j = i + 1; j < cities; j++)
                {
                    if (roads[i, j] != Inf)
                    {
                        totalDistances += roads[i, j];
                    }
                }
            }

            yield return totalDistances;
        }
    }
}
