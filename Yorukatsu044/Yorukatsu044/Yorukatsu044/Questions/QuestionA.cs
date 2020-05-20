using Yorukatsu044.Questions;
using Yorukatsu044.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu044.Questions
{
    /// <summary>
    /// ABC058 A
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abc = inputStream.ReadIntArray();
            yield return abc[1] - abc[0] == abc[2] - abc[1] ? "YES" : "NO";
        }
    }
}
