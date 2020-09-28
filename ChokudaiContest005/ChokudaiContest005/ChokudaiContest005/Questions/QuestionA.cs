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
using System.Diagnostics.CodeAnalysis;

namespace ChokudaiContest005.Questions
{
    public class QuestionA : AtCoderQuestionBase
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
            var queries = new Queue<Query>(10000);
            var (idMap, idCount) = GetIDs(colorMap);

            var sets = new SortedSet<Coordinate>[idCount, maxColor];
            for (int i = 0; i < idCount; i++)
            {
                for (int j = 0; j < maxColor; j++)
                {
                    sets[i, j] = new SortedSet<Coordinate>();
                }
            }

            while (true)
            {
                (idMap, idCount) = GetIDs(colorMap);

                for (int i = 0; i < idCount; i++)
                {
                    for (int j = 0; j < maxColor; j++)
                    {
                        sets[i, j].Clear();
                    }
                }

                for (int row = 0; row < size; row++)
                {
                    for (int column = 0; column < idMap[row].Length; column++)
                    {
                        var c = new Coordinate(row, column);
                        var color = colorMap[row][column];
                        var id = idMap[row][column];

                        foreach (var diff in diffs)
                        {
                            var next = c + diff;
                            if (next.InMap(size))
                            {
                                var nextColor = colorMap[next.Row][next.Column];
                                if (nextColor != color)
                                {
                                    sets[id, nextColor].Add(next);
                                }
                            }
                        }
                    }
                }

                var maxCount = 0;
                var maxID = 0;
                var maxC = 0;

                for (int id = 0; id < idCount; id++)
                {
                    for (int color = 0; color < maxColor; color++)
                    {
                        if (sets[id, color].Count > maxCount)
                        {
                            maxID = id;
                            maxC = color;
                            maxCount = sets[id, color].Count;
                        }
                    }
                }

                if (maxCount == 0)
                {
                    break;
                }
                else
                {
                    var row = 0;
                    var column = 0;
                    for (int i = 0; i < idMap.Data.Length; i++)
                    {
                        if (idMap.Data[i] == maxID)
                        {
                            row = i / size;
                            column = i % size;
                            break;
                        }
                    }

                    queries.Enqueue(new Query(row + 1, column + 1, maxC + 1));

                    for (row = 0; row < size; row++)
                    {
                        for (column = 0; column < size; column++)
                        {
                            if (idMap[row][column] == maxID)
                            {
                                colorMap[row][column] = maxC;
                                var me = new Coordinate(row, column);
                                foreach (var diff in diffs)
                                {
                                    var next = me + diff;
                                    if (next.InMap(size) && colorMap[next.Row][next.Column] == maxC)
                                    {
                                        idMap[next.Row][next.Column] = maxID;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            io.WriteLine(queries.Count);
            while (queries.Count > 0)
            {
                io.WriteLine(queries.Dequeue());
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
