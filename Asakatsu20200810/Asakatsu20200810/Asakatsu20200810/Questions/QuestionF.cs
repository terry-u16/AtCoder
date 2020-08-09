using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Asakatsu20200810.Algorithms;
using Asakatsu20200810.Collections;
using Asakatsu20200810.Extensions;
using Asakatsu20200810.Numerics;
using Asakatsu20200810.Questions;
using System.Numerics;

namespace Asakatsu20200810.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc008/tasks/arc008_3
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var graph = Enumerable.Repeat(0, n).Select(_ => new List<Edge>(n)).ToArray();

            var participants = new Participant[n];
            for (int i = 0; i < participants.Length; i++)
            {
                var (x, y, t, r) = inputStream.ReadValue<int, int, int, int>();
                participants[i] = new Participant(new Complex(x, y), t, r);
            }

            for (int i = 0; i < participants.Length; i++)
            {
                for (int j = 0; j < participants.Length; j++)
                {
                    graph[i].Add(new Edge(i, j, participants[i].ThrowTo(participants[j])));
                }
            }

            double[] GetDistancesFrom(int startNode)
            {
                const double Inf = 1e50;
                var distances = Enumerable.Repeat(Inf, n).ToArray();
                distances[startNode] = 0;
                var todo = new PriorityQueue<State>(false);
                todo.Enqueue(new State(startNode, 0));

                while (todo.Count > 0)
                {
                    var current = todo.Dequeue();
                    if (current.Distance > distances[current.Node])
                    {
                        continue;
                    }

                    foreach (var edge in graph[current.Node])
                    {
                        var nextDistance = current.Distance + edge.Time;
                        if (distances[edge.To] > nextDistance)
                        {
                            distances[edge.To] = nextDistance;
                            todo.Enqueue(new State(edge.To, nextDistance));
                        }
                    }
                }

                return distances;
            }

            var times = GetDistancesFrom(0);
            Array.Sort(times);
            var time = 0.0;
            for (int i = times.Length - 1; i >= 1; i--)
            {
                time = Math.Max(time, times[i] + (n - 1 - i));
            }

            yield return time;
        }


        private readonly struct State : IComparable<State>
        {
            public int Node { get; }
            public double Distance { get; }

            public State(int node, double distance)
            {
                Node = node;
                Distance = distance;
            }

            public int CompareTo(State other) => Distance.CompareTo(other.Distance);
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Edge
        {
            public int From { get; }
            public int To { get; }
            public double Time { get; }

            public Edge(int from, int to, double time)
            {
                From = from;
                To = to;
                Time = time;
            }

            public override string ToString() => $"{From} --{Time:0.00}s--> {To}";
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Participant
        {
            public Complex Coordinate { get; }
            public int ThrowSpeed { get; }
            public int CatchSpeed { get; }

            public Participant(Complex coordinate, int throwSpeed, int catchSpeed)
            {
                Coordinate = coordinate;
                ThrowSpeed = throwSpeed;
                CatchSpeed = catchSpeed;
            }

            public double ThrowTo(Participant other)
            {
                var speed = Math.Min(ThrowSpeed, other.CatchSpeed);
                return (Coordinate - other.Coordinate).Magnitude / speed;
            }

            public override string ToString() => $"{nameof(Coordinate)}: {Coordinate}, {nameof(CatchSpeed)}: {CatchSpeed}";
        }
    }
}
