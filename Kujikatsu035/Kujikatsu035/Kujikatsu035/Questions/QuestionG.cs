using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu035.Algorithms;
using Kujikatsu035.Collections;
using Kujikatsu035.Extensions;
using Kujikatsu035.Numerics;
using Kujikatsu035.Questions;
using Kujikatsu035.Graphs;

namespace Kujikatsu035.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc083/tasks/arc083_c
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        BasicGraph tree;
        int[] x;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            tree = new BasicGraph(n);
            if (n == 1)
            {
                yield return "POSSIBLE";
                yield break;
            }

            var p = inputStream.ReadIntArray().Select(pi => pi - 1).ToArray();
            x = inputStream.ReadIntArray();

            for (int i = 0; i < p.Length; i++)
            {
                var me = i + 1;
                tree.AddEdge(new BasicEdge(p[i], me));
            }

            yield return Dfs(0) != Sum.NG ? "POSSIBLE" : "IMPOSSIBLE";
        }

        Sum Dfs(int current)
        {
            if (!tree[current].Any())
            {
                return new Sum(x[current], 0);
            }
            else
            {
                var childrenSum = tree[current].Select(e => Dfs(e.To.Index)).ToArray();
                var composables = new bool[childrenSum.Length + 1, x[current] + 1];
                composables[0, 0] = true;

                if (childrenSum.Any(s => s == Sum.NG))
                {
                    return Sum.NG;
                }

                var total = childrenSum.Sum(s => s.ColorA + s.ColorB);

                for (int i = 0; i < childrenSum.Length; i++)
                {
                    for (int sum = 0; sum <= x[current]; sum++)
                    {
                        var child = childrenSum[i];
                        if (composables[i, sum])
                        {
                            var nextA = sum + child.ColorA;
                            var nextB = sum + child.ColorB;
                            if (nextA <= x[current])
                            {
                                composables[i + 1, nextA] = true;
                            }
                            if (nextB <= x[current])
                            {
                                composables[i + 1, nextB] = true;
                            }
                        }
                    }
                }

                for (int sameColorChildrenSum = x[current]; sameColorChildrenSum >= 0; sameColorChildrenSum--)
                {
                    if (composables[childrenSum.Length, sameColorChildrenSum])
                    {
                        var me = x[current] - sameColorChildrenSum;
                        if (me >= 0)
                        {
                            return new Sum(me + sameColorChildrenSum, total - sameColorChildrenSum);
                        }
                    }
                }

                return Sum.NG;
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Sum : IEquatable<Sum>
        {
            public int ColorA { get; }
            public int ColorB { get; }

            public static Sum NG => new Sum(-1, -1);

            public Sum(int colorA, int colorB)
            {
                ColorA = colorA;
                ColorB = colorB;
            }

            public void Deconstruct(out int colorA, out int colorB) => (colorA, colorB) = (ColorA, ColorB);
            public override string ToString() => $"{nameof(ColorA)}: {ColorA}, {nameof(ColorB)}: {ColorB}";

            public override bool Equals(object obj)
            {
                return obj is Sum sum && Equals(sum);
            }

            public bool Equals(Sum other)
            {
                return ColorA == other.ColorA &&
                       ColorB == other.ColorB;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(ColorA, ColorB);
            }

            public static bool operator ==(Sum left, Sum right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(Sum left, Sum right)
            {
                return !(left == right);
            }
        }
    }
}
