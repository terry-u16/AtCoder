using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu038.Algorithms;
using Kujikatsu038.Collections;
using Kujikatsu038.Extensions;
using Kujikatsu038.Numerics;
using Kujikatsu038.Questions;

namespace Kujikatsu038.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/tenka1-2018-beginner/tasks/tenka1_2018_d
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var k = 0;

            for (int i = 2; i * (i - 1) / 2 <= n; i++)
            {
                if (i * (i - 1) / 2 == n)
                {
                    k = i;
                    break;
                }
            }

            if (k == 0)
            {
                yield return "No";
                yield break;
            }

            var lists = Enumerable.Repeat(0, k).Select(_ => new List<int>(k - 1)).ToArray();
            var current = 1;

            for (int me = 0; me < lists.Length; me++)
            {
                for (int other = me + 1; other < lists.Length; other++)
                {
                    lists[me].Add(current);
                    lists[other].Add(current);
                    current++;
                }
            }

            yield return "Yes";
            yield return lists.Length;
            foreach (var list in lists)
            {
                yield return $"{list.Count} {list.Join(' ')}";
            }
        }
    }
}
