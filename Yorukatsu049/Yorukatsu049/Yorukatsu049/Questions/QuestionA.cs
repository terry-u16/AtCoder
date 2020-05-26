using Yorukatsu049.Questions;
using Yorukatsu049.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu049.Questions
{
    /// <summary>
    /// ABC081 B
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            yield return a.Min(CountDiv2);
        }

        int CountDiv2(int n)
        {
            var count = 0;
            while (n % 2 == 0)
            {
                n /= 2;
                count++;
            }
            return count;
        }
    }
}
