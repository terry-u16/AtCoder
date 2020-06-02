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
    /// https://atcoder.jp/contests/abc148/tasks/abc148_e
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadLong();

            if (n % 2 == 1)
            {
                yield return 0;
            }
            else
            {
                long count = 0;
                n /= 2;
                for (int i = 1; Pow5(i) <= n; i++)
                {
                    count += n / Pow5(i);
                }
                yield return count;
            }
        }

        long Pow5(int n)
        {
            long result = 1;
            for (int i = 0; i < n; i++)
            {
                result *= 5;
            }
            return result;
        }
    }
}
