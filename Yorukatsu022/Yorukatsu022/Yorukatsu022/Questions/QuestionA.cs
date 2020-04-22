using Yorukatsu022.Questions;
using Yorukatsu022.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu022.Questions
{
    /// <summary>
    /// ABC089 A
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            yield return inputStream.ReadInt() / 3;
        }
    }
}
