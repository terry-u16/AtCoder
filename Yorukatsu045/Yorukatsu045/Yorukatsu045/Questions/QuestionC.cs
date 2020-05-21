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
    /// ARC047 C
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var last = s[0];
            var count = 0;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] != last)
                {
                    count++;
                }
                last = s[i];
            }

            yield return count;
        }
    }
}
