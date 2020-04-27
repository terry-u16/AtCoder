using Yorukatsu026.Questions;
using Yorukatsu026.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu026.Questions
{
    /// <summary>
    /// ABC055 A
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            yield return 800 * n - 200 * (n / 15);
        }
    }
}
