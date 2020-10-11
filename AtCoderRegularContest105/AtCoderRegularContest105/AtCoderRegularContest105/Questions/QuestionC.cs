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
using AtCoderRegularContest105.Algorithms;
using AtCoderRegularContest105.Collections;
using AtCoderRegularContest105.Numerics;
using AtCoderRegularContest105.Questions;
using System.Diagnostics.CodeAnalysis;

namespace AtCoderRegularContest105.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var camels = io.ReadInt();
            var parts = io.ReadInt();

            var weights = io.ReadIntArray(camels);
            weights.Sort();

            var weightCandidates = new SortedSet<int>();

            for (var flag = BitSet.One; flag < (1 << camels); flag++)
            {
                var sum = 0;
                for (int i = 0; i < weights.Length; i++)
                {
                    if (flag[i])
                    {
                        sum += weights[i];
                    }
                }
                weightCandidates.Add(sum);
            }

            var bridges = new Bridge[parts];

            for (int i = 0; i < bridges.Length; i++)
            {
                bridges[i] = new Bridge(io.ReadInt(), io.ReadInt());
            }

            if (weights.Max() > bridges.Min(b => b.Strength))
            {
                io.WriteLine(-1);
                return;
            }

            bridges.Sort();

            var toCheckList = new List<Bridge>(weightCandidates.Count);

            var index = 0;

            foreach (var w in weightCandidates.Reverse())
            {
                var maxLength = 0;

                while (index < bridges.Length && bridges[index].Strength >= w)
                {
                    maxLength.ChangeMax(bridges[index].Length);
                    index++;
                }

                if (maxLength > 0)
                {
                    toCheckList.Add(new Bridge(maxLength, w));
                }
            }


            var toCheck = toCheckList.ToArray();
            var distances = new int[camels, camels];
            var ls = new int[camels];
            int min = int.MaxValue;

            foreach (var weightOrder in PermutationAlgorithms.GetPermutations(weights))
            {
                distances.Fill(0);
                var ws = weightOrder.Span;

                foreach (var bridge in toCheck)
                {
                    for (int i = 0; i < camels; i++)
                    {
                        var w = ws[i];

                        for (int j = i + 1; j < camels; j++)
                        {
                            w += ws[j];

                            if (bridge.Strength < w)
                            {
                                distances[i, j].ChangeMax(bridge.Length);
                            }
                        }
                    }
                }

                ls.AsSpan().Clear();

                for (int i = 1; i < camels; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        ls[i].ChangeMax(ls[j] + distances[j, i]);
                    }
                }

                min.ChangeMin(ls[^1]);
            }

            io.WriteLine(min);
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Bridge : IComparable<Bridge>
        {
            public readonly int Length;
            public readonly int Strength;

            public Bridge(int length, int strength)
            {
                Length = length;
                Strength = strength;
            }

            public int CompareTo([AllowNull] Bridge other)
            {
                var comp = other.Strength - Strength;

                if (comp != 0)
                {
                    return comp;
                }
                else
                {
                    return Length - other.Length;
                }
            }

            public void Deconstruct(out int length, out int strength) => (length, strength) = (Length, Strength);
            public override string ToString() => $"{nameof(Length)}: {Length}, {nameof(Strength)}: {Strength}";
        }
    }
}
