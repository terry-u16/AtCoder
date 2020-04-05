using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AtCoderBeginnerContest161.Extensions;

namespace AtCoderBeginnerContest161.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<string> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var n = nm[0];
            var m = nm[1];
            var a = inputStream.ReadIntArray();

            var total = a.Sum();
            var canSelectCount = a.Count(i => i >= (double)total / (4 * m));

            if (canSelectCount >= m)
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
