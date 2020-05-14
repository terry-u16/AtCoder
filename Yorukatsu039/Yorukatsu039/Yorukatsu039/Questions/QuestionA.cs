using Yorukatsu039.Questions;
using Yorukatsu039.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu039.Questions
{
    /// <summary>
    /// ABC128 A
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var ap = inputStream.ReadIntArray();
            var a = ap[0];
            var p = ap[1];
            p += a * 3;
            yield return p / 2;
        }
    }
}
