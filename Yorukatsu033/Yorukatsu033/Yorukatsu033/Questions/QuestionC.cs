using Yorukatsu033.Questions;
using Yorukatsu033.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu033.Questions
{
    /// <summary>
    /// ABC061 C
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadLongArray();
            var n = nk[0];
            var k = nk[1];
            var counts = new long[100001];

            for (int i = 0; i < n; i++)
            {
                var ab = inputStream.ReadIntArray();
                var a = ab[0];
                var b = ab[1];
                counts[a] += b;
            }

            long picked = 0;
            for (int i = 1; i < counts.Length; i++)
            {
                picked += counts[i];

                if (picked >= k)
                {
                    yield return i;
                    yield break;
                }
            }
        }
    }
}
