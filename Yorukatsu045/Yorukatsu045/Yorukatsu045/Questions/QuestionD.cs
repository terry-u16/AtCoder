using Yorukatsu045.Questions;
using Yorukatsu045.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu045.Questions
{
    /// <summary>
    /// ABC057 C
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadLong();

            var min = int.MaxValue;
            for (long i = 1; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    min = Math.Min(min, F(n / i, i));
                }
            }

            yield return min;
        }

        int F(long a, long b) => Math.Max(F(a), F(b));

        int F(long a)
        {
            var count = 0;
            while (a > 0)
            {
                a /= 10;
                count++;
            }
            return count;
        }
    }
}
