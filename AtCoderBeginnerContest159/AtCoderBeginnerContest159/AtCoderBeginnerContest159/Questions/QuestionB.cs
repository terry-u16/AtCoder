using AtCoderBeginnerContest159.Questions;
using AtCoderBeginnerContest159.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest159.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();

            var subLength = (s.Length - 1) / 2;

            yield return IsKaibun(s) 
                && IsKaibun(s.Substring(0, subLength)) 
                && IsKaibun(s.Substring((s.Length + 3) / 2 - 1, subLength))
                ? "Yes" : "No";
        }

        private bool IsKaibun(string s) => s.SequenceEqual(s.Reverse());
    }
}
