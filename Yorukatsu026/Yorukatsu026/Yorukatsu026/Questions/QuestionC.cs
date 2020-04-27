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
    /// ABC082 B
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine().ToCharArray();
            var t = inputStream.ReadLine().ToCharArray();
            Array.Sort(s);
            Array.Sort(t);
            Array.Reverse(t);

            yield return new string(s).CompareTo(new string(t)) < 0 ? "Yes" : "No";
        }
    }
}
