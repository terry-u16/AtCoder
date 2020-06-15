using Kujikatsu001.Questions;
using Kujikatsu001.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Kujikatsu001.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc107/tasks/arc101_a
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadIntArray();
            var k = nk[1];
            var x = inputStream.ReadIntArray();

            var minLength = int.MaxValue;

            for (int i = 0; i + k - 1 < x.Length; i++)
            {
                var length = Math.Max(Math.Abs(x[i]), Math.Abs(x[i + k - 1]));
                if (Math.Sign(x[i]) * Math.Sign(x[i + k - 1]) < 0)
                {
                    length += 2 * Math.Min(Math.Abs(x[i]), Math.Abs(x[i + k - 1]));
                }

                minLength = Math.Min(minLength, length);
            }

            yield return minLength; 
        }
    }
}
