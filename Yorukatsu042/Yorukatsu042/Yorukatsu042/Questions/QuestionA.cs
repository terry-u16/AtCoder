using Yorukatsu042.Questions;
using Yorukatsu042.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu042.Questions
{
    /// <summary>
    /// ABC080 B
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            if (n % F(n) == 0)
            {
                yield return "Yes";
            }
            else
            {
                yield return "No";
            }
        }

        int F(int x)
        {
            var sum = 0;
            while (x > 0)
            {
                sum += x % 10;
                x /= 10;
            }
            return sum;
        }
    }
}
