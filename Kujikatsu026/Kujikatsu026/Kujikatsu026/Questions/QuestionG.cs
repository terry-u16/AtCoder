using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu026.Algorithms;
using Kujikatsu026.Collections;
using Kujikatsu026.Extensions;
using Kujikatsu026.Numerics;
using Kujikatsu026.Questions;

namespace Kujikatsu026.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc049/tasks/arc065_b
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k, l) = inputStream.ReadValue<int, int, int>();
            var roads = new UnionFindTree(n);
            var railways = new UnionFindTree(n);

            for (int i = 0; i < k; i++)
            {
                var (p, q) = inputStream.ReadValue<int, int>();
                p--;
                q--;
                roads.Unite(p, q);
            }

            for (int i = 0; i < l; i++)
            {
                var (r, s) = inputStream.ReadValue<int, int>();
                r--;
                s--;
                railways.Unite(r, s);
            }

            var counter = new Counter<RootPair>();
            var pairs = new RootPair[n];

            for (int i = 0; i < n; i++)
            {
                var pair = new RootPair(roads._nodes[i].FindRoot().ID, railways._nodes[i].FindRoot().ID);
                pairs[i] = pair;
                counter[pair]++;
            }

            var results = new Queue<long>();
            foreach (var pair in pairs)
            {
                results.Enqueue(counter[pair]);
            }

            yield return results.Join(' ');
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct RootPair : IEquatable<RootPair>
        {
            public int RoadRoot { get; }
            public int RailwayRoot { get; }

            public RootPair(int roadRoot, int railwayRoot)
            {
                RoadRoot = roadRoot;
                RailwayRoot = railwayRoot;
            }

            public void Deconstruct(out int roadRoot, out int railwayRoot) => (roadRoot, railwayRoot) = (RoadRoot, RailwayRoot);
            public override string ToString() => $"{nameof(RoadRoot)}: {RoadRoot}, {nameof(RailwayRoot)}: {RailwayRoot}";

            public override bool Equals(object obj)
            {
                return obj is RootPair pair && Equals(pair);
            }

            public bool Equals(RootPair other)
            {
                return RoadRoot == other.RoadRoot &&
                       RailwayRoot == other.RailwayRoot;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(RoadRoot, RailwayRoot);
            }

            public static bool operator ==(RootPair left, RootPair right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(RootPair left, RootPair right)
            {
                return !(left == right);
            }
        }
    }
}
