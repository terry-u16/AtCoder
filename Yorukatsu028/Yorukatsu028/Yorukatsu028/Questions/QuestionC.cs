using Yorukatsu028.Questions;
using Yorukatsu028.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu028.Questions
{
    /// <summary>
    /// ARC068 C
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var x = inputStream.ReadLong();

            var elevenCount = x / 11;
            x -= 11 * elevenCount;
            long count = 2 * elevenCount;

            if (x == 0)
            {
                yield return count;
            }
            else if (x <= 6)
            {
                yield return count + 1;
            }
            else
            {
                yield return count + 2;
            }
        }
    }
}
