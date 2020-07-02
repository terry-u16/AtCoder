using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu018.Algorithms;
using Kujikatsu018.Collections;
using Kujikatsu018.Extensions;
using Kujikatsu018.Numerics;
using Kujikatsu018.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Kujikatsu018.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc014/tasks/agc014_c
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (h, w, k) = inputStream.ReadValue<int, int, int>();
            var map = new char[h][];
            var (startRow, startColumn) = (0, 0);
            for (int r = 0; r < h; r++)
            {
                map[r] = inputStream.ReadLine().ToCharArray();
                for (int c = 0; c < w; c++)
                {
                    if (map[r][c] == 'S')
                    {
                        startRow = r;
                        startColumn = c;
                    }
                }
            }

            var walkAndDeletes = Dijkstra(map, startRow, startColumn, k);
            var min = int.MaxValue;
            for (int row = 0; row < h; row++)
            {
                min = Math.Min(min, walkAndDeletes[row, 0].Walk);
                min = Math.Min(min, walkAndDeletes[row, w - 1].Walk);
            }
            for (int column = 0; column < w; column++)
            {
                min = Math.Min(min, walkAndDeletes[0, column].Walk);
                min = Math.Min(min, walkAndDeletes[h - 1, column].Walk);
            }

            yield return (min + k - 1) / k;
        }

        WalkAndDelete[,] Dijkstra(char[][] map, int startRow, int startColumn, int k)
        {
            var height = map.Length;
            var width = map[0].Length;
            var distances = new WalkAndDelete[height, width].SetAll((i, j) => WalkAndDelete.Inf);
            distances[startRow, startColumn] = new WalkAndDelete();

            var queue = new PriorityQueue<Status>(false);
            queue.Enqueue(new Status(new Grid(startRow, startColumn), new WalkAndDelete(0, 0)));

            var diff = new (int dr, int dc)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

            while (queue.Count > 0)
            {
                var (currentGrid, currentWalkAndDelete) = queue.Dequeue();
                var (currentRow, currentColumn) = currentGrid;
                var (currentWalk, currentDelete) = currentWalkAndDelete;
                if (currentWalkAndDelete.CompareTo(distances[currentRow, currentColumn]) > 0)
                {
                    continue;
                }

                foreach (var (dr, dc) in diff)
                {
                    var nextRow = currentRow + dr;
                    var nextColumn = currentColumn + dc;
                    if (unchecked((uint)nextRow) < height && unchecked((uint)nextColumn) < width)
                    {
                        if (map[nextRow][nextColumn] == '.')
                        {
                            var nextWalkAndDelete = new WalkAndDelete(currentWalk + 1, currentDelete);
                            if (nextWalkAndDelete.CompareTo(distances[nextRow, nextColumn]) < 0)
                            {
                                distances[nextRow, nextColumn] = nextWalkAndDelete;
                                queue.Enqueue(new Status(new Grid(nextRow, nextColumn), nextWalkAndDelete));
                            }
                        }
                        else if (map[nextRow][nextColumn] == '#')
                        {
                            var nextDelete = currentDelete + 1;
                            var turn = (nextDelete + k - 1) / k;
                            var nextWalk = Math.Max(currentWalk + 1, k * turn + 1);
                            var nextWalkAndDelete = new WalkAndDelete(nextWalk, nextDelete);
                            if (nextWalkAndDelete.CompareTo(distances[nextRow, nextColumn]) < 0)
                            {
                                distances[nextRow, nextColumn] = nextWalkAndDelete;
                                queue.Enqueue(new Status(new Grid(nextRow, nextColumn), nextWalkAndDelete));
                            }
                        }
                    }
                }
            }

            return distances;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Status : IComparable<Status>
        {
            public Grid Grid { get; }
            public WalkAndDelete WalkAndDelete { get; }

            public Status(Grid grid, WalkAndDelete walkAndDelete)
            {
                Grid = grid;
                WalkAndDelete = walkAndDelete;
            }

            public void Deconstruct(out Grid grid, out WalkAndDelete walkAndDelete) => (grid, walkAndDelete) = (Grid, WalkAndDelete);
            public override string ToString() => $"{nameof(Grid)}: {Grid}, {nameof(WalkAndDelete)}: {WalkAndDelete}";

            public int CompareTo([AllowNull] Status other) => WalkAndDelete.CompareTo(other.WalkAndDelete);
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Grid
        {
            public int Row { get; }
            public int Column { get; }

            public Grid(int row, int column)
            {
                Row = row;
                Column = column;
            }

            public void Deconstruct(out int row, out int column) => (row, column) = (Row, Column);
            public override string ToString() => $"{nameof(Row)}: {Row}, {nameof(Column)}: {Column}";
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct WalkAndDelete : IComparable<WalkAndDelete>
        {
            public int Walk { get; }
            public int Delete { get; }

            public static WalkAndDelete Inf => new WalkAndDelete(1 << 28, 1 << 28);

            public WalkAndDelete(int walk, int delete)
            {
                Walk = walk;
                Delete = delete;
            }

            public void Deconstruct(out int walk, out int delete) => (walk, delete) = (Walk, Delete);
            public override string ToString() => $"{nameof(Walk)}: {Walk}, {nameof(Delete)}: {Delete}";

            public int CompareTo([AllowNull] WalkAndDelete other)
            {
                var comp = Walk - other.Walk;
                if (comp != 0)
                {
                    return comp;
                }
                else
                {
                    return Delete - other.Delete;
                }
            }
        }
    }
}
