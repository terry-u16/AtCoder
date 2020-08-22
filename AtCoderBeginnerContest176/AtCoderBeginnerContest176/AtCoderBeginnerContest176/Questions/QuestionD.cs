using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest176.Algorithms;
using AtCoderBeginnerContest176.Collections;
using AtCoderBeginnerContest176.Extensions;
using AtCoderBeginnerContest176.Numerics;
using AtCoderBeginnerContest176.Questions;
using AtCoderBeginnerContest176.Graphs;

namespace AtCoderBeginnerContest176.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (height, width) = inputStream.ReadValue<int, int>();
            var (startRow, startColumn) = inputStream.ReadValue<int, int>();
            var (goalRow, goalColumn) = inputStream.ReadValue<int, int>();
            startRow--;
            startColumn--;
            goalRow--;
            goalColumn--;

            var canEnter = new bool[height][];
            for (int i = 0; i < canEnter.Length; i++)
            {
                canEnter[i] = inputStream.ReadLine().Select(c => c == '.').ToArray();
            }

            var rooms = new int[height, width].SetAll((i, j) => -1);
            var roomNo = 0;

            void GridBfs(int startRow, int startColumn, int roomNo)
            {
                var todo = new Queue<(int row, int column)>();
                todo.Enqueue((startRow, startColumn));
                var diffs = new (int dr, int dc)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
                rooms[startRow, startColumn] = roomNo;

                while (todo.Count > 0)
                {
                    var (currentRow, currentColumn) = todo.Dequeue();
                    foreach (var (dr, dc) in diffs)
                    {
                        var nextRow = currentRow + dr;
                        var nextColumn = currentColumn + dc;
                        if (unchecked((uint)nextRow < height && (uint)nextColumn < width) 
                            && canEnter[nextRow][nextColumn] && rooms[nextRow, nextColumn] == -1)
                        {
                            rooms[nextRow, nextColumn] = roomNo;
                            todo.Enqueue((nextRow, nextColumn));
                        }
                    }
                }
            }

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    if (canEnter[row][column] && rooms[row, column] == -1)
                    {
                        GridBfs(row, column, roomNo);
                        roomNo++;
                    }
                }
            }

            var graph = new BasicGraph(roomNo);
            var set = new HashSet<RoomPair>();
            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    var currentRoom = rooms[row, column];
                    if (currentRoom != -1)
                    {
                        for (int dr = -2; dr <= 2; dr++)
                        {
                            for (int dc = -2; dc <= 2; dc++)
                            {
                                var nextRow = row + dr;
                                var nextColumn = column + dc;

                                if (unchecked((uint)nextRow < height && (uint)nextColumn < width) &&
                                    rooms[nextRow, nextColumn] != -1 && set.Add(new RoomPair(currentRoom, rooms[nextRow, nextColumn])))
                                {
                                    var nextRoom = rooms[nextRow, nextColumn];
                                    graph.AddEdge(new BasicEdge(currentRoom, nextRoom));
                                    graph.AddEdge(new BasicEdge(nextRoom, currentRoom));
                                }
                            }
                        }
                    }
                }
            }

            int GraphBfs(int startNode, int goalNode)
            {
                const int Inf = 1 << 28;
                var todo = new Queue<int>();
                todo.Enqueue(startNode);
                var distances = Enumerable.Repeat(Inf, graph.NodeCount).ToArray();
                distances[startNode] = 0;

                while (todo.Count > 0)
                {
                    var current = todo.Dequeue();
                    foreach (var edge in graph[current])
                    {
                        var next = edge.To.Index;
                        if (distances[next] == Inf)
                        {
                            distances[next] = distances[current] + 1;
                            todo.Enqueue(next);
                        }
                    }
                }

                if (distances[goalNode] < Inf)
                {
                    return distances[goalNode];
                }
                else
                {
                    return -1;
                }
            }

            yield return GraphBfs(rooms[startRow, startColumn], rooms[goalRow, goalColumn]);
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct RoomPair : IEquatable<RoomPair>
        {
            public int RoomA { get; }
            public int RoomB { get; }

            public RoomPair(int roomA, int roomB)
            {
                if (roomA > roomB)
                {
                    (roomA, roomB) = (roomB, roomA);
                }

                RoomA = roomA;
                RoomB = roomB;
            }

            public void Deconstruct(out int roomA, out int roomB) => (roomA, roomB) = (RoomA, RoomB);
            public override string ToString() => $"{nameof(RoomA)}: {RoomA}, {nameof(RoomB)}: {RoomB}";

            public override bool Equals(object obj)
            {
                return obj is RoomPair pair && Equals(pair);
            }

            public bool Equals(RoomPair other)
            {
                return RoomA == other.RoomA &&
                       RoomB == other.RoomB;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(RoomA, RoomB);
            }

            public static bool operator ==(RoomPair left, RoomPair right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(RoomPair left, RoomPair right)
            {
                return !(left == right);
            }
        }
    }
}
