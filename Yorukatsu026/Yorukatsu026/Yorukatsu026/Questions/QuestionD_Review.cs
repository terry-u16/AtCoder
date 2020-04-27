using Yorukatsu026.Questions;
using Yorukatsu026.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu026.Questions
{
    /// <summary>
    /// ABC121 D復習
    /// </summary>
    public class QuestionD_Review : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var ab = inputStream.ReadLongArray();
            long a = ab[0];
            long b = ab[1];

            var minEven = ((a + 1) / 2) * 2;
            var maxOdd = ((b + 1) / 2) * 2 - 1;

            var evenOddCount = (maxOdd + 1 - minEven) / 2;
            long bit = evenOddCount % 2 == 0 ? 0 : 1;

            if (a != minEven)
            {
                bit ^= a;
            }
            if (b != maxOdd)
            {
                bit ^= b;
            }
            yield return bit;
        }
    }
}
