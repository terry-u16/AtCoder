using Yorukatsu039.Questions;
using Yorukatsu039.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu039.Questions
{
    /// <summary>
    /// ABC066 B
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();

            var max = 0;
            for (int i = 1; i * 2 < s.Length; i++)
            {
                if (s.Substring(0, i) == s.Substring(i, i))
                {
                    max = 2 * i;
                }
            }

            yield return max;
        }
    }
}
