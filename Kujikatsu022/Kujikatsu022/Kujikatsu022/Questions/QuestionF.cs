using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu022.Algorithms;
using Kujikatsu022.Collections;
using Kujikatsu022.Extensions;
using Kujikatsu022.Numerics;
using Kujikatsu022.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Kujikatsu022.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc167/tasks/abc167_f
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var bracketSequences = new BracketSequence[n];
            for (int i = 0; i < n; i++)
            {
                var current = 0;
                var bottom = 0;
                foreach (var c in inputStream.ReadLine())
                {
                    if (c == '(')
                    {
                        current++;
                    }
                    else
                    {
                        bottom = Math.Min(bottom, --current);
                    }
                }
                bracketSequences[i] = new BracketSequence(bottom, current);
            }

            var positiveSequences = bracketSequences.Where(b => b.Total >= 0).ToArray();
            var negativeSequences = bracketSequences.Where(b => b.Total < 0).Select(b => new BracketSequence(b.Bottom - b.Total, -b.Total)).ToArray();
            Array.Sort(positiveSequences);
            Array.Sort(negativeSequences);

            var positive = 0;
            foreach (var brackets in positiveSequences)
            {
                if (positive + brackets.Bottom < 0)
                {
                    yield return "No";
                    yield break;
                }
                else
                {
                    positive += brackets.Total;
                }
            }

            var negative = 0;
            foreach (var brackets in negativeSequences)
            {
                if (negative + brackets.Bottom < 0)
                {
                    yield return "No";
                    yield break;
                }
                else
                {
                    negative += brackets.Total;
                }
            }

            yield return positive == negative ? "Yes" : "No";
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct BracketSequence : IComparable<BracketSequence>
        {
            public int Bottom { get; }
            public int Total { get; }

            public BracketSequence(int bottom, int total)
            {
                Bottom = bottom;
                Total = total;
            }

            public void Deconstruct(out int bottom, out int total) => (bottom, total) = (Bottom, Total);
            public override string ToString() => $"{nameof(Bottom)}: {Bottom}, {nameof(Total)}: {Total}";

            public int CompareTo([AllowNull] BracketSequence other) => other.Bottom - Bottom;
        }
    }
}
