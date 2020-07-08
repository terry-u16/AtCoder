using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu023.Algorithms;
using Kujikatsu023.Collections;
using Kujikatsu023.Extensions;
using Kujikatsu023.Numerics;
using Kujikatsu023.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Kujikatsu023.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc116/tasks/abc116_d
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k) = inputStream.ReadValue<int, int>();
            var sushis = new PriorityQueue<Sushi>(true);

            for (int i = 0; i < n; i++)
            {
                var (t, d) = inputStream.ReadValue<int, int>();
                sushis.Enqueue(new Sushi(d, t));
            }

            var eatenKinds = new HashSet<int>(n);
            var duplicatedSushis = new PriorityQueue<Sushi>(false);

            long satisfaction = 0;
            for (int i = 0; i < k; i++)
            {
                var sushi = sushis.Dequeue();
                satisfaction += sushi.Value;
                if (!eatenKinds.Add(sushi.Kind))
                {
                    duplicatedSushis.Enqueue(sushi);
                }
            }

            long maxSatisfaction = satisfaction + GetKindBonus(eatenKinds.Count);

            foreach (var sushi in sushis)
            {
                if (!eatenKinds.Contains(sushi.Kind) && duplicatedSushis.Count > 0)
                {
                    satisfaction -= duplicatedSushis.Dequeue().Value;
                    satisfaction += sushi.Value;
                    eatenKinds.Add(sushi.Kind);
                    maxSatisfaction = Math.Max(maxSatisfaction, satisfaction + GetKindBonus(eatenKinds.Count));
                }
            }

            yield return maxSatisfaction;
        }

        long GetKindBonus(long kind) => kind * kind;

        [StructLayout(LayoutKind.Auto)]
        readonly struct Sushi : IComparable<Sushi>
        {
            public int Value { get; }
            public int Kind { get; }

            public Sushi(int value, int kind)
            {
                Value = value;
                Kind = kind;
            }

            public void Deconstruct(out int value, out int kind) => (value, kind) = (Value, Kind);
            public override string ToString() => $"{nameof(Value)}: {Value}, {nameof(Kind)}: {Kind}";

            public int CompareTo([AllowNull] Sushi other) => Value - other.Value;
        }
    }
}
