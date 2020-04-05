using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AtCoderBeginnerContest161.Extensions;

namespace AtCoderBeginnerContest161.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<string> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadLongArray();
            var n = nk[0];
            var k = nk[1];

            var diff = Math.Abs(n - k);

            if (diff > n)
            {
                yield return n.ToString();
                yield break;
            }

            n %= k;
            yield return Math.Min(n, Math.Abs(n - k)).ToString();
        }
    }
}
