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
using System.Runtime.Intrinsics.X86;
using Training20201019.Algorithms;
using Training20201019.Collections;
using Training20201019.Numerics;
using Training20201019.Questions;
using Training20201019.Graphs;

namespace Training20201019.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var tree = new BasicGraph(n);
            var edgeIndice = new Dictionary<Edge, int>(n);

            for (int i = 0; i < n - 1; i++)
            {
                var u = io.ReadInt();
                var v = io.ReadInt();
                u--;
                v--;
                tree.AddEdge(u, v);
                tree.AddEdge(v, u);
                edgeIndice[new Edge(u, v)] = i;
            }

            var pathCount = io.ReadInt();

            var paths = new Path[pathCount];

            for (int i = 0; i < paths.Length; i++)
            {
                var u = io.ReadInt();
                var v = io.ReadInt();
                u--;
                v--;
                paths[i] = new Path(u, v);
            }

            var pathFlags = new uint[n - 1];

            for (int i = 0; i < pathCount; i++)
            {
                InitDfs(0, -1, i);
            }

            var dp = DpDfs(0, -1);

            io.WriteLine(dp[(1 << pathCount) - 1]);

            State InitDfs(int current, int parent, int pathIndex)
            {
                foreach (var next in tree[current])
                {
                    if (next == parent)
                    {
                        continue;
                    }

                    var state = InitDfs(next, current, pathIndex);

                    if (state == State.None)
                    {
                        if (next == paths[pathIndex].From)
                        {
                            pathFlags[edgeIndice[new Edge(current, next)]] |= 1u << pathIndex;
                            return State.FirstFound;
                        }
                        else if (next == paths[pathIndex].To)
                        {
                            pathFlags[edgeIndice[new Edge(current, next)]] |= 1u << pathIndex;
                            return State.SecondFound;
                        }
                    }
                    else if (state == State.Completed)
                    {
                        return State.Completed;
                    }
                    else if (state == State.FirstFound)
                    {
                        pathFlags[edgeIndice[new Edge(current, next)]] |= 1u << pathIndex;

                        if (paths[pathIndex].To == current)
                        {
                            return State.Completed;
                        }
                        else
                        {
                            return State.FirstFound;
                        }
                    }
                    else if (state == State.SecondFound)
                    {
                        pathFlags[edgeIndice[new Edge(current, next)]] |= 1u << pathIndex;

                        if (paths[pathIndex].From == current)
                        {
                            return State.Completed;
                        }
                        else
                        {
                            return State.SecondFound;
                        }
                    }
                }

                return State.None;
            }

            long[] DpDfs(int current, int parent)
            {
                var dp = new long[1 << pathCount];

                if (tree[current].Length == 1 && parent != -1)
                {
                    dp[0] = 1;
                    return dp;
                }

                foreach (var next in tree[current])
                {
                    if (next == parent)
                    {
                        continue;
                    }

                    var currentPathFlag = pathFlags[edgeIndice[new Edge(current, next)]];
                    var childDp = DpDfs(next, current);

                    for (var flag = BitSet.Zero; flag < 1 << pathCount; flag++)
                    {
                        // 黒くする
                        dp[flag | currentPathFlag] += childDp[flag];

                        // 白くする
                        dp[flag] += childDp[flag];
                    }
                }

                return dp;
            }
        }

        enum State
        {
            None,
            FirstFound,
            SecondFound,
            Completed
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Edge : IEquatable<Edge>
        {
            public readonly int From;
            public readonly int To;

            public Edge(int from, int to)
            {
                from.SwapIfLargerThan(ref to);
                From = from;
                To = to;
            }

            public void Deconstruct(out int from, out int to) => (from, to) = (From, To);

            public override bool Equals(object obj)
            {
                return obj is Edge edge && Equals(edge);
            }

            public bool Equals(Edge other)
            {
                return From == other.From &&
                       To == other.To;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(From, To);
            }

            public override string ToString() => $"{nameof(From)}: {From}, {nameof(To)}: {To}";

            public static bool operator ==(Edge left, Edge right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(Edge left, Edge right)
            {
                return !(left == right);
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Path
        {
            public readonly int From;
            public readonly int To;

            public Path(int from, int to)
            {
                From = from;
                To = to;
            }

            public void Deconstruct(out int from, out int to) => (from, to) = (From, To);
            public override string ToString() => $"{nameof(From)}: {From}, {nameof(To)}: {To}";
        }
    }
}
