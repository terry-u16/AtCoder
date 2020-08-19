using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu066.Algorithms;
using Kujikatsu066.Collections;
using Kujikatsu066.Extensions;
using Kujikatsu066.Numerics;
using Kujikatsu066.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Kujikatsu066.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/nikkei2019-2-qual/tasks/nikkei2019_2_qual_c
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray().Select((v, i) => new ValueAndIndex(v, i)).ToArray();
            var b = inputStream.ReadIntArray().Select((v, i) => new ValueAndIndex(v, i)).ToArray();
            Array.Sort(a);
            Array.Sort(b);

            if (!InitialCheck(a, b))
            {
                yield return "No";
            }
            else
            {
                var swapLoops = new UnionFindTree(n);
                for (int i = 0; i < a.Length; i++)
                {
                    swapLoops.Unite(a[i].Index, b[i].Index);
                }

                if (swapLoops.Groups > 1)
                {
                    yield return "Yes";
                }
                else
                {
                    var ok = false;
                    for (int i = 0; i + 1 < b.Length; i++)
                    {
                        if (a[i + 1].Value <= b[i].Value)
                        {
                            ok = true;
                            break;
                        }
                    }

                    if (ok)
                    {
                        yield return "Yes";
                    }
                    else
                    {
                        yield return "No";
                    }
                }
            }
        }

        bool InitialCheck(ReadOnlySpan<ValueAndIndex> a, ReadOnlySpan<ValueAndIndex> b)
        {
            var ok = true;
            for (int i = 0; i < a.Length; i++)
            {
                ok &= a[i].Value <= b[i].Value;
            }
            return ok;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct ValueAndIndex : IComparable<ValueAndIndex>
        {
            public int Value { get; }
            public int Index { get; }

            public ValueAndIndex(int value, int index)
            {
                Value = value;
                Index = index;
            }

            public void Deconstruct(out int value, out int index) => (value, index) = (Value, Index);
            public override string ToString() => $"{nameof(Value)}: {Value}, {nameof(Index)}: {Index}";

            public int CompareTo([AllowNull] ValueAndIndex other) => Value - other.Value;
        }
    }
}
