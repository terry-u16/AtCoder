using Yorukatsu034.Questions;
using Yorukatsu034.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu034.Questions
{
    /// <summary>
    /// ABC045 A
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var a = inputStream.ReadInt();
            var b = inputStream.ReadInt();
            var h = inputStream.ReadInt();
            yield return (a + b) * h / 2;
        }
    }
}
