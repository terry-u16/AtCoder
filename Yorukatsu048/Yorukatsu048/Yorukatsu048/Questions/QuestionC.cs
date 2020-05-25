using Yorukatsu048.Questions;
using Yorukatsu048.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu048.Questions
{
    /// <summary>
    /// ARC069 C
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var sc = inputStream.ReadLongArray();
            var s = sc[0];
            var c = sc[1];

            var scc = Math.Min(s, c / 2);
            s -= scc;
            c -= 2 * scc;

            if (c > 0)
            {
                scc += c / 4;
            }

            yield return scc;
        }
    }
}
