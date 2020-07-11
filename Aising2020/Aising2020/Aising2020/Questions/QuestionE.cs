using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aising2020.Algorithms;
using Aising2020.Collections;
using Aising2020.Extensions;
using Aising2020.Numerics;
using Aising2020.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Aising2020.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var n = inputStream.ReadInt();
                var camels = new Camel[n];
                long happiness = 0;

                for (int i = 0; i < n; i++)
                {
                    var (k, l, r) = inputStream.ReadValue<int, int, int>();
                    k--;
                    camels[i] = new Camel(k, l, r);
                    happiness += Math.Min(l, r);
                }

                var plusWaiting = new Queue<Camel>(camels.Where(c => c.Diff >= 0).OrderBy(c => c.K));
                var minusWainting = new Queue<Camel>(camels.Where(c => c.Diff < 0).Where(c => c.K < n - 1).OrderByDescending(c => c.K));
                var plusSelected = new PriorityQueue<Camel>(false);
                var minusSelected = new PriorityQueue<Camel>(true);

                for (int i = 0; i < n; i++)
                {
                    while (plusWaiting.Count > 0 && plusWaiting.Peek().K == i)
                        plusSelected.Enqueue(plusWaiting.Dequeue());
                    while (plusSelected.Count > i + 1)
                        plusSelected.Dequeue();
                }

                for (int i = n - 1; i >= 0; i--)
                {
                    while (minusWainting.Count > 0 && minusWainting.Peek().K == i)
                        minusSelected.Enqueue(minusWainting.Dequeue());
                    while (minusSelected.Count > n - i + 1)
                        minusSelected.Dequeue();
                }

                foreach (var selectedCamel in plusSelected)
                {
                    happiness += selectedCamel.Diff;
                }

                foreach (var selectedCamel in minusSelected)
                {
                    happiness -= selectedCamel.Diff;
                }


                yield return happiness;
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Camel : IComparable<Camel>
        {
            public int K { get; }
            public int L { get; }
            public int R { get; }
            public int Diff => L - R;

            public Camel(int k, int l, int r)
            {
                K = k;
                L = l;
                R = r;
            }

            public override string ToString() => $"{nameof(K)}: {K}, {nameof(L)}: {L}, {nameof(R)}: {R}";

            public int CompareTo([AllowNull] Camel other) => Diff - other.Diff;
        }
    }
}
