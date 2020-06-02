using Yorukatsu054.Questions;
using Yorukatsu054.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu054.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc093/tasks/arc094_a
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abc = inputStream.ReadIntArray();

            var count = 0;
            while (abc[0] != abc[1] || abc[1] != abc[2] | abc[2] != abc[0])
            {
                Array.Sort(abc);
                var diff1 = abc[2] - abc[0];
                var diff2 = abc[2] - abc[1];
                if (diff2 != 0)
                {
                    abc[0]++;
                    abc[1]++;
                }
                else
                {
                    abc[0] += 2;
                }

                count++;
            }

            yield return count;
        }
    }
}
