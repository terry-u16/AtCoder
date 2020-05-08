using Yorukatsu035.Questions;
using Yorukatsu035.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu035.Questions
{
    /// <summary>
    /// ABC106 C
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var k = inputStream.ReadLong();

            for (int i = 0; i < k; i++)
            {
                if (s[i] != '1' || i == k - 1)
                {
                    yield return s[i];
                    yield break;
                }
            }
        }
    }
}
