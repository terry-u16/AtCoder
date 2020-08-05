using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu052.Algorithms;
using Kujikatsu052.Collections;
using Kujikatsu052.Extensions;
using Kujikatsu052.Numerics;
using Kujikatsu052.Questions;

namespace Kujikatsu052.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            Array.Sort(a);
            var min = a[0];
            var max = a[^1];

            var operations = new Queue<(int, int)>();
            var mids = a[1..^1];
            foreach (var minus in mids.Where(ai => ai < 0))
            {
                operations.Enqueue((max, minus));
                max -= minus;
            }

            foreach (var geZero in mids.Where(ai => ai >= 0))
            {
                operations.Enqueue((min, geZero));
                min -= geZero;
            }

            operations.Enqueue((max, min));
            max -= min;

            yield return max;
            foreach (var op in operations.Select(op => $"{op.Item1} {op.Item2}"))
            {
                yield return op;
            }
        }
    }
}
