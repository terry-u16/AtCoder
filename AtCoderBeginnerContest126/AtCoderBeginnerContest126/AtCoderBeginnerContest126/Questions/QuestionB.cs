using AtCoderBeginnerContest126.Questions;
using AtCoderBeginnerContest126.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest126.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var upper = int.Parse(s.Substring(0, 2));
            var lower = int.Parse(s.Substring(2, 2));

            if (!MayBeMonth(upper) && !MayBeMonth(lower))
            {
                yield return "NA";
            }
            else if (!MayBeMonth(upper))
            {
                yield return "YYMM";
            }
            else if (!MayBeMonth(lower))
            {
                yield return "MMYY";
            }
            else
            {
                yield return "AMBIGUOUS";
            }
        }

        bool MayBeMonth(int n) => n > 0 && n <= 12;
    }
}
