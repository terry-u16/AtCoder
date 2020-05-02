using AtCoderBeginnerContest130.Questions;
using AtCoderBeginnerContest130.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest130.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nx = inputStream.ReadIntArray();
            var n = nx[0];
            var x = nx[1];
            var l = inputStream.ReadIntArray();

            var total = 0;
            for (int bounce = 0; bounce < l.Length; bounce++)
            {
                total += l[bounce];
                if (total > x)
                {
                    yield return bounce + 1;
                    yield break;
                }
            }

            yield return n + 1;
        }
    }
}
