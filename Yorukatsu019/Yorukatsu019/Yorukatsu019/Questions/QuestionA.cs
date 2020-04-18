using Yorukatsu019.Questions;
using Yorukatsu019.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu019.Questions
{
    /// <summary>
    /// ABC117 B
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            int n = inputStream.ReadInt();
            var l = inputStream.ReadIntArray();

            Array.Sort(l);
            Array.Reverse(l);
            if (l[0] < l.Skip(1).Sum())
            {
                yield return "Yes";
            }
            else
            {
                yield return "No";
            }
        }
    }
}
