using AtCoderBeginnerContest141.Questions;
using AtCoderBeginnerContest141.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest141.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();

            for (int i = 0; i < s.Length; i++)
            {
                var count = i + 1;
                var c = s[i];
                if (count % 2 == 1 && c == 'L')
                {
                    yield return "No";
                    yield break;
                }
                if (count % 2 == 0 && c == 'R')
                {
                    yield return "No";
                    yield break;
                }
            }

            yield return "Yes";
        }
    }
}
