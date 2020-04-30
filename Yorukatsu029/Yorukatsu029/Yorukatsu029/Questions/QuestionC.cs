using Yorukatsu029.Questions;
using Yorukatsu029.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu029.Questions
{
    /// <summary>
    /// ABC091 C
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadLongArray();
            var n = nm[0];
            var m = nm[1];

            if (n == 1 && m == 1)
            {
                yield return 1;
            }
            else if (n == 1)
            {
                yield return Math.Max(m - 2, 0);
            }
            else if (m == 1)
            {
                yield return Math.Max(n - 2, 0);
            }
            else
            {
                yield return (n - 2) * (m - 2);
            }
        }
    }
}
