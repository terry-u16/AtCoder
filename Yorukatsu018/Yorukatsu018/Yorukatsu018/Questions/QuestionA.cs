using Yorukatsu018.Questions;
using Yorukatsu018.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu018.Questions
{
    /// <summary>
    /// ABC069 A
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            yield return (nm[0] - 1) * (nm[1] - 1);
        }
    }
}
