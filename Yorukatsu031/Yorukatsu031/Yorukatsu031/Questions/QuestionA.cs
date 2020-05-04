using Yorukatsu031.Questions;
using Yorukatsu031.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu031.Questions
{
    /// <summary>
    /// ABC051 A
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            yield return s.Replace(',', ' ');
        }
    }
}
