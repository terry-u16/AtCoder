using Yorukatsu058.Questions;
using Yorukatsu058.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu058.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc072/tasks/arc082_a
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var counts = new int[100001];

            foreach (var ai in a)
            {
                counts[ai]++;
            }

            var max = Enumerable.Range(1, 99999).Max(i => counts[i - 1] + counts[i] + counts[i + 1]);
            yield return max;
        }
    }
}
