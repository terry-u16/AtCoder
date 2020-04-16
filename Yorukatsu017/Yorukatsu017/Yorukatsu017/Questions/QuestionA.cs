using Yorukatsu017.Questions;
using Yorukatsu017.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu017.Questions
{
    /// <summary>
    /// ABC089 B
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var s = inputStream.ReadLine();

            yield return s.Contains('Y') ? "Four" : "Three";
        }
    }
}
