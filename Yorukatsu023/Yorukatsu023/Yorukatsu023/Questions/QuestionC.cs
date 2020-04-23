using Yorukatsu023.Questions;
using Yorukatsu023.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu023.Questions
{
    /// <summary>
    /// ABC126 C
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadIntArray();
            var n = nk[0];
            var k = nk[1];

            var exp = 0.0;

            for (int i = 1; i <= n; i++)
            {
                exp += 1 / (Math.Pow(2, GetPow(i, k)));
            }

            exp /= n;

            yield return exp;
        }

        int GetPow(int n, int k)
        {
            var pow = 0;
            while (n < k)
            {
                n *= 2;
                pow++;
            }
            return pow;
        }
    }
}
