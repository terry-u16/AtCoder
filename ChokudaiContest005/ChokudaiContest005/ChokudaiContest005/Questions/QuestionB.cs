using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ChokudaiContest005.Algorithms;
using ChokudaiContest005.Collections;
using ChokudaiContest005.Numerics;
using ChokudaiContest005.Questions;

namespace ChokudaiContest005.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        Diff[] diffs = new Diff[] { new Diff(-1, 0), new Diff(1, 0), new Diff(0, -1), new Diff(0, 1) };

        public override void Solve(IOManager io)
        {
            var sw = new Stopwatch();
            sw.Start();
            var rand = new XorShift();

            var _ = io.ReadInt();
            var size = io.ReadInt();
            var maxColor = io.ReadInt();

            var colorMap = LoadMap(io, size);
            var (idMap, idCount) = GetIDs(colorMap);
            var tried = new bool[idCount];

            var (queries, firstID) = TryFirst(colorMap, idMap, idCount, maxColor);
            tried[firstID] = true;
            var last = idCount - 1;

            int count = 1;
            bool end = false;
            var low = size * 42 / 100;
            var high = size * 58 / 100;

            for (int row = low; row < high && !end; row++)
            {
                for (int column = low; column < high && !end; column++)
                {
                    var c = new Coordinate(row, column);
                    if (!tried[idMap[row][column]])
                    {
                        tried[idMap[row][column]] = true;
                        var q = Try(c, colorMap, idMap, maxColor);

                        if (q.Count < queries.Count)
                        {
                            queries = q;
                        }
                        count++;
                    }

                    if (sw.ElapsedMilliseconds >= 2850)
                    {
                        end = true;
                    }
                }
            }

            io.WriteLine(queries.Count);
            while (queries.Count > 0)
            {
                io.WriteLine(queries.Dequeue());
            }
        }

        (Queue<Query>, int id) TryFirst(Map colorMap, Map idMap, int maxID, int overallColor)
        {
            var idCount = new int[maxID];

            for (int i = 0; i < idMap.Data.Length; i++)
            {
                idCount[idMap.Data[i]]++;
            }

            var max = 0;
            for (int i = 0; i < idCount.Length; i++)
            {
                if (idCount[i] > max)
                {
                    max = i;
                }
            }

            for (int i = 0; i < idMap.Data.Length; i++)
            {
                if (idMap.Data[i] == max)
                {
                    var c = new Coordinate(i / idMap.Size, i % idMap.Size);
                    return (Try(c, colorMap, idMap, overallColor), max);
                }
            }

            return (null, -1);
        }

        Queue<Query> Try(Coordinate start, Map initialColorMap, Map initialIDMap, int overallColor)
        {
            var size = initialColorMap.Size;
            var colorMapArray = new int[size * size];
            var idMapArray = new int[size * size];
            initialColorMap.Data.AsSpan().CopyTo(colorMapArray);
            initialIDMap.Data.AsSpan().CopyTo(idMapArray);
            var idMap = new Map(size, idMapArray);

            var myID = initialIDMap[start.Row][start.Column];
            var myColor = initialColorMap.Data[start.ToIndex(size)];

            var queue = new Queue<Query>();
            var sorrounded = new bool[size * size];

            var seen = new bool[size * size];
            var colorQueues = Enumerable.Repeat(0, overallColor).Select(_ => new Queue<Coordinate>()).ToArray();

            while (true)
            {
                seen.AsSpan().Fill(false);
                for (int i = 0; i < colorQueues.Length; i++)
                {
                    colorQueues[i].Clear();
                }

                for (int row = 0; row < size; row++)
                {
                    for (int column = 0; column < size; column++)
                    {
                        var p = new Coordinate(row, column);
                        var index = p.ToIndex(size);
                        if (idMap.Data[index] == myID && !sorrounded[index])
                        {
                            var sorroundedMe = true;

                            foreach (var diff in diffs)
                            {
                                var next = p + diff;
                                var yourIndex = next.ToIndex(size);
                                if (next.InMap(size) && idMap.Data[yourIndex] != myID)
                                {
                                    if (!seen[yourIndex])
                                    {
                                        colorQueues[initialColorMap.Data[yourIndex]].Enqueue(next);
                                        seen[yourIndex] = true;
                                    }

                                    sorroundedMe = false;
                                }
                            }

                            sorrounded[index] = sorroundedMe;
                        }
                    }
                }

                var maxColor = 0;

                for (int color = 0; color < colorQueues.Length; color++)
                {
                    if (colorQueues[color].Count > colorQueues[maxColor].Count)
                    {
                        maxColor = color;
                    }
                }

                if (colorQueues[maxColor].Count == 0)
                {
                    return queue;
                }
                else
                {
                    queue.Enqueue(new Query(start.Row + 1, start.Column + 1, maxColor + 1));
                    myColor = maxColor;

                    while (colorQueues[maxColor].Count > 0)
                    {
                        var current = colorQueues[maxColor].Dequeue();
                        Dfs(current, maxColor);
                    }
                }

                void Dfs(Coordinate current, int color)
                {
                    idMap[current.Row][current.Column] = myID;

                    foreach (var diff in diffs)
                    {
                        var next = current + diff;
                        if (next.InMap(size) && idMap[next.Row][next.Column] != myID && initialColorMap[next.Row][next.Column] == color)
                        {
                            Dfs(next, color);
                        }
                    }
                }
            }
        }

        Map LoadMap(IOManager io, int size)
        {
            var panels = new int[size * size];

            for (int i = 0; i < panels.Length; i++)
            {
                panels[i] = io.ReadChar() - '1';
            }

            return new Map(size, panels);
        }

        (Map idMap, int idCount) GetIDs(Map map)
        {
            var ids = new int[map.Size * map.Size];
            ids.AsSpan().Fill(-1);
            var idMap = new Map(map.Size, ids);

            var id = 0;

            for (int row = 0; row < map.Size; row++)
            {
                for (int column = 0; column < map.Size; column++)
                {
                    var c = new Coordinate(row, column);
                    if (ids[c.ToIndex(map.Size)] == -1)
                    {
                        Dfs(c, map[c.Row][c.Column], id++);
                    }
                }
            }

            return (idMap, id);

            void Dfs(Coordinate current, int color, int id)
            {
                ids[current.ToIndex(map.Size)] = id;

                foreach (var diff in diffs)
                {
                    var next = current + diff;

                    if (next.InMap(map.Size) && map[next.Row][next.Column] == color && ids[next.ToIndex(map.Size)] == -1)
                    {
                        Dfs(next, color, id);
                    }
                }
            }
        }

        (int score, int maxColor) CalculateScore(int[][] map)
        {
            Span<int> counts = stackalloc int[10];
            for (int row = 0; row < map.Length; row++)
            {
                var r = map[row];
                for (int column = 0; column < map[row].Length; column++)
                {
                    counts[r[column]]++;
                }
            }

            var maxColor = 0;
            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] > counts[maxColor])
                {
                    maxColor = i;
                }
            }

            return (counts[maxColor] * 100, maxColor);
        }



        [StructLayout(LayoutKind.Auto)]
        readonly struct Coordinate : IEquatable<Coordinate>, IComparable<Coordinate>
        {
            public int Row { get; }
            public int Column { get; }

            public Coordinate(int row, int column)
            {
                Row = row;
                Column = column;
            }

            public bool InMap(int size) => unchecked((uint)Row < size && (uint)Column < size);
            public int ToIndex(int size) => Row * size + Column;
            public void Deconstruct(out int x, out int y) => (x, y) = (Row, Column);
            public override string ToString() => $"{nameof(Row)}: {Row}, {nameof(Column)}: {Column}";

            public override bool Equals(object obj)
            {
                return obj is Coordinate coordinate && Equals(coordinate);
            }

            public bool Equals(Coordinate other)
            {
                return Row == other.Row &&
                       Column == other.Column;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Row, Column);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int CompareTo(Coordinate other)
            {
                var comp = Row - other.Row;
                if (comp != 0)
                {
                    return comp;
                }
                else
                {
                    return Column - other.Column;
                }
            }

            public static Coordinate operator +(Coordinate coordinate, Diff diff) => new Coordinate(coordinate.Row + diff.DR, coordinate.Column + diff.DC);

            public static bool operator ==(Coordinate left, Coordinate right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(Coordinate left, Coordinate right)
            {
                return !(left == right);
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Diff
        {
            public int DR { get; }
            public int DC { get; }

            public Diff(int dr, int dc)
            {
                DR = dr;
                DC = dc;
            }

            public void Deconstruct(out int dr, out int dc) => (dr, dc) = (DR, DC);
            public override string ToString() => $"{nameof(DR)}: {DR}, {nameof(DC)}: {DC}";
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct IndexAndColor
        {
            public int Index { get; }
            public int Color { get; }

            public IndexAndColor(int index, int color)
            {
                Index = index;
                Color = color;
            }

            public void Deconstruct(out int index, out int color) => (index, color) = (Index, Color);
            public override string ToString() => $"{nameof(Index)}: {Index}, {nameof(Color)}: {Color}";
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Query
        {
            public int Row { get; }
            public int Column { get; }
            public int Color { get; }

            public Query(int row, int column, int color)
            {
                Row = row;
                Column = column;
                Color = color;
            }

            public override string ToString() => $"{Row} {Column} {Color}";
        }

        struct Map
        {
            public int[] Data { get; }
            public int Size { get; }

            public Map(int size, int[] data)
            {
                Size = size;
                Data = data;
            }

            public Span<int> this[int row]
            {
                get => Data.AsSpan(row * Size, Size);
            }
        }

    }
}
