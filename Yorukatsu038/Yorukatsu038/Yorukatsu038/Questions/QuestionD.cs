using Yorukatsu038.Questions;
using Yorukatsu038.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu038.Questions
{
    /// <summary>
    /// ABC049 C
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var toErases = new string[] { "eraser", "erase", "dreamer", "dream" };
            foreach (var toErase in toErases)
            {
                s = s.Replace(toErase, string.Empty);
            }
            yield return s == string.Empty ? "YES" : "NO";
        }
    }
}
