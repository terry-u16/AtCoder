using AtCoderBeginnerContest139.Questions;
using AtCoderBeginnerContest139.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest139.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var t = inputStream.ReadLine();

            var count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == t[i])
                {
                    count++;
                }
            }
            yield return count;
        }
    }
}
