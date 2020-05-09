using Yorukatsu036.Questions;
using Yorukatsu036.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu036.Questions
{
    /// <summary>
    /// ABC072 B
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();

            var builder = new StringBuilder();

            for (int i = 0; i < s.Length; i += 2)
            {
                builder.Append(s[i]);
            }

            yield return builder.ToString();
        }
    }
}
