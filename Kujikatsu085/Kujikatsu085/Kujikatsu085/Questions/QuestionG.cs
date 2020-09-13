using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu085.Algorithms;
using Kujikatsu085.Collections;
using Kujikatsu085.Extensions;
using Kujikatsu085.Numerics;
using Kujikatsu085.Questions;
using Kujikatsu085.Graphs;

namespace Kujikatsu085.Questions
{
    public class QuestionG : AtCoderQuestionBase
    {
        const int White = 0;
        const int Black = 1;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (cityCount, roadCount) = inputStream.ReadValue<int, int>();
            var hasRoad = new bool[cityCount, cityCount];
            for (int i = 0; i < roadCount; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                a--;
                b--;
                hasRoad[a, b] = true;
                hasRoad[b, a] = true;
            }

            var graph = new BasicGraph(cityCount);

            for (int i = 0; i < cityCount; i++)
            {
                for (int j = i + 1; j < cityCount; j++)
                {
                    if (!hasRoad[i, j])
                    {
                        graph.AddEdge(new BasicEdge(i, j));
                        graph.AddEdge(new BasicEdge(j, i));
                    }
                }
            }

            var colors = Enumerable.Repeat(-1, cityCount).ToArray();
            var composable = new bool[cityCount + 1, cityCount + 1];
            composable[0, 0] = true;
            var current = 0;

            for (int city = 0; city < cityCount; city++)
            {
                if (colors[city] == -1)
                {
                    var (blacks, whites) = Paint(city, Black);

                    if (blacks < 0 || whites < 0)
                    {
                        yield return -1;
                        yield break;
                    }

                    for (int i = 0; i <= cityCount; i++)
                    {
                        if (i + blacks <= cityCount)
                        {
                            composable[current + 1, i + blacks] |= composable[current, i];
                        }

                        if (i + whites <= cityCount)
                        {
                            composable[current + 1, i + whites] |= composable[current, i];
                        }
                    }

                    current++;
                }
            }

            var min = int.MaxValue;

            for (int i = 0; i <= cityCount; i++)
            {
                if (composable[current, i])
                {
                    var remain = cityCount - i;
                    min = Math.Min(min, i * (i - 1) / 2 + remain * (remain - 1) / 2);
                }
            }

            yield return min;

            (int blacks, int whites) Paint(int current, int color)
            {
                colors[current] = color;
                var blacks = 0;
                var whites = 0;

                if (color == White)
                {
                    whites++;
                }
                else
                {
                    blacks++;
                }

                foreach (var edge in graph[current])
                {
                    var next = edge.To.Index;
                    if (colors[next] == color)
                    {
                        return (int.MinValue, int.MinValue);
                    }
                    else if (colors[next] == -1)
                    {
                        var (b, w) = Paint(next, color == White ? Black : White);
                        if (b < 0 || w < 0)
                        {
                            return (b, w);
                        }
                        blacks += b;
                        whites += w;
                    }
                }

                return (blacks, whites);
            }
        }
    }
}
