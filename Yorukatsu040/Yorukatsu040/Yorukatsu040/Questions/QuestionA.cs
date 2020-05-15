using Yorukatsu040.Questions;
using Yorukatsu040.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu040.Questions
{
    /// <summary>
    /// ABC116
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abc = inputStream.ReadIntArray();
            var a = abc[0];
            var b = abc[1];
            yield return a * b / 2;
        }
    }
}
