using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using JudgeSystemUpdateTestContest202004.Extensions;

namespace JudgeSystemUpdateTestContest202004.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<string> Solve(TextReader inputStream)
        {
            var slr = inputStream.ReadIntArray();
            var s = slr[0];
            var l = slr[1];
            var r = slr[2];

            if (l <= s && s <= r)
            {
                yield return s.ToString();
            }
            else if (s < l)
            {
                yield return l.ToString();
            }
            else
            {
                yield return r.ToString();
            }
        }
    }
}
