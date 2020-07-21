using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu037.Algorithms;
using Kujikatsu037.Collections;
using Kujikatsu037.Extensions;
using Kujikatsu037.Numerics;
using Kujikatsu037.Questions;

namespace Kujikatsu037.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc140/tasks/abc140_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var eatens = inputStream.ReadIntArray().Select(i => i - 1).ToArray();
            var satisfactions = inputStream.ReadIntArray();
            var combos = inputStream.ReadIntArray();

            var last = eatens[0];
            var satisfaction = satisfactions[last];

            foreach (var eaten in eatens.Skip(1))
            {
                satisfaction += satisfactions[eaten];
                if (last + 1 == eaten)
                {
                    satisfaction += combos[last];
                }
                last = eaten;
            }

            yield return satisfaction;
        }
    }
}
