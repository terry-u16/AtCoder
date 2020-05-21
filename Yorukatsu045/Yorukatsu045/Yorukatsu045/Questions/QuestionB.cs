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
    /// ABC144 C
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadLong();
            var div = GetMaxDivisior(n);
            var another = n / div;
            yield return div + another - 2;
        }

        long GetMaxDivisior(long n)
        {
            for (long i = (long)Math.Sqrt(n) + 1; i >= 0; i--)
            {
                if (n % i == 0)
                {
                    return i;
                }
            }

            return 1;
        }
    }
}
