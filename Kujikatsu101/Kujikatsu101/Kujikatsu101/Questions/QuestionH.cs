using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu101.Algorithms;
using Kujikatsu101.Collections;
using Kujikatsu101.Numerics;
using Kujikatsu101.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Kujikatsu101.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc061/tasks/arc061_c
    /// </summary>
    public class QuestionH : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            const int INF = 1 << 28;
            var stations = io.ReadInt();
            var railways = io.ReadInt();

            var graph = Construct(io, stations, railways);
            var distance = BFS(0);
            var result = distance[stations - 1];

            if (result < INF)
            {
                io.WriteLine(result);
            }
            else
            {
                io.WriteLine(-1);
            }
            

            int[] BFS(int start)
            {
                var distances = new int[graph.Length];
                distances.AsSpan().Fill(INF);
                distances[start] = 0;
                var deque = new Deque<int>();
                deque.EnqueueLast(start);

                while (deque.Count > 0)
                {
                    var current = deque.DequeueFirst();

                    foreach (var (next, costs) in graph[current])
                    {
                        var nextDistance = distances[current] + (costs ? 1 : 0);
                        if (nextDistance < distances[next])
                        {
                            distances[next] = nextDistance;

                            if (costs)
                            {
                                deque.EnqueueLast(next);
                            }
                            else
                            {
                                deque.EnqueueFirst(next);
                            }
                        }
                    }
                }

                return distances;
            }
        }

        List<Edge>[] Construct(IOManager io, int stations, int railwayCount)
        {
            int stationID = stations;
            var railways = new Railway[railwayCount];
            var graph = Enumerable.Repeat(0, stations).Select(_ => new List<Edge>()).ToList();

            for (int i = 0; i < railways.Length; i++)
            {
                var p = io.ReadInt() - 1;
                var q = io.ReadInt() - 1;
                var c = io.ReadInt() - 1;
                railways[i] = new Railway(p, q, c);
            }

            Array.Sort(railways);

            var rail = 0;

            for (int co = 0; co < 1_000_000; co++)
            {
                var myStations = new Dictionary<int, int>();
                var myRailways = new List<Railway>();

                while (rail < railways.Length && railways[rail].Company == co)
                {
                    if (!myStations.ContainsKey(railways[rail].From))
                    {
                        myStations.Add(railways[rail].From, stationID++);
                    }
                    if (!myStations.ContainsKey(railways[rail].To))
                    {
                        myStations.Add(railways[rail].To, stationID++);
                    }

                    myRailways.Add(railways[rail++]);
                }

                foreach (var (localID, globalID) in myStations)
                {
                    graph.Add(new List<Edge>());
                    // 乗車（有料）
                    graph[localID].Add(new Edge(globalID, true));
                    // 下車（無料）
                    graph[globalID].Add(new Edge(localID, false));
                }

                foreach (var r in myRailways)
                {
                    graph[myStations[r.From]].Add(new Edge(myStations[r.To], false));
                    graph[myStations[r.To]].Add(new Edge(myStations[r.From], false));
                }
            }

            return graph.ToArray();
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Railway : IComparable<Railway>
        {
            public int From { get; }
            public int To { get; }
            public int Company { get; }

            public Railway(int from, int to, int company)
            {
                From = from;
                To = to;
                Company = company;
            }

            public override string ToString() => $"{nameof(From)}: {From}, {nameof(To)}: {To}, {nameof(Company)}: {Company}";

            public int CompareTo([AllowNull] Railway other) => Company - other.Company;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Edge
        {
            public int To { get; }
            public bool Costs { get; }

            public Edge(int to, bool costs)
            {
                To = to;
                Costs = costs;
            }

            public void Deconstruct(out int to, out bool costs) => (to, costs) = (To, Costs);
            public override string ToString() => $"{nameof(To)}: {To}, {nameof(Costs)}: {Costs}";
        }
    }
}
