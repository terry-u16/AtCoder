using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu009.Algorithms;
using Kujikatsu009.Collections;
using Kujikatsu009.Extensions;
using Kujikatsu009.Numerics;
using Kujikatsu009.Questions;

namespace Kujikatsu009.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc097/tasks/arc097_b
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, pairCount) = inputStream.ReadValue<int, int>();
            var p = inputStream.ReadIntArray().Select(i => i - 1).ToArray();
            var pairs = new UnionFindTree(n);

            for (int i = 0; i < pairCount; i++)
            {
                var (x, y) = inputStream.ReadValue<int, int>();
                x--;
                y--;
                pairs.Unite(x, y);
            }

            yield return Enumerable.Range(0, n).Count(i => pairs.IsInSameGroup(p[i], i));
        }
    }
}
