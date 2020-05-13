using Yorukatsu038.Questions;
using Yorukatsu038.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu038.Questions
{
    /// <summary>
    /// ARC079 B
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            const int n = 50;
            var k = inputStream.ReadLong();
            var div = k / n;
            var mod = (int)(k % n);

            var upper = n * 2 + div - mod;
            var lower = n + div - (mod + 1);

            yield return n;
            yield return string.Join(" ", Enumerable.Repeat(upper, mod).Concat(Enumerable.Repeat(lower, n - mod)));
        }
    }
}
