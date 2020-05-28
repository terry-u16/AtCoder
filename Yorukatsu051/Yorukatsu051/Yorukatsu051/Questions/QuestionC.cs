using Yorukatsu051.Questions;
using Yorukatsu051.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu051.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();

            var div2Count = a.Sum(GetDiv2Count);
            yield return div2Count >= n / 2 * 2 ? "Yes" : "No";
        }

        int GetDiv2Count(int n)
        {
            var count = 0;
            while ((n & 1) == 0)
            {
                count++;
                n >>= 1;
            }
            return Math.Min(count, 2);
        }
    }
}
