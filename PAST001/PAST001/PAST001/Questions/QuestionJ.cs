using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PAST001.Algorithms;
using PAST001.Collections;
using PAST001.Numerics;
using PAST001.Questions;
using PAST001.Graphs;
using PAST001.Graphs.Algorithms;

namespace PAST001.Questions
{
    public class QuestionJ : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var height = io.ReadInt();
            var width = io.ReadInt();

            var map = new int[height][];

            for (int row = 0; row < height; row++)
            {
                map[row] = io.ReadIntArray(width);
            }

            var graph = new WeightedGraph(height * width);
            Span<(int dr, int dc)> diffs = stackalloc (int dr, int dc)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    var index = GetIndex(row, column);
                    foreach (var (dr, dc) in diffs)
                    {
                        var nr = row + dr;
                        var nc = column + dc;

                        if (unchecked((uint)nr < (uint)height && (uint)nc < (uint)width))
                        {
                            var other = GetIndex(nr, nc);
                            graph.AddEdge(index, other, map[nr][nc]);
                        }
                    }
                }
            }

            long min = long.MaxValue;
            var dijkstra = new Dijkstra(graph);

            var fromLeftBottom = dijkstra.GetDistancesFrom(GetIndex(height - 1, 0));
            var fromRightTop = dijkstra.GetDistancesFrom(GetIndex(0, width - 1));
            var fromRightBottom = dijkstra.GetDistancesFrom(GetIndex(height - 1, width - 1));

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    var index = GetIndex(row, column);
                    var distance = fromLeftBottom[index] + fromRightTop[index] + fromRightBottom[index] - 2 * map[row][column];
                    min.ChangeMin(distance);
                }
            }

            io.WriteLine(min);

            int GetIndex(int row, int column) => row * width + column;
        }
    }
}
