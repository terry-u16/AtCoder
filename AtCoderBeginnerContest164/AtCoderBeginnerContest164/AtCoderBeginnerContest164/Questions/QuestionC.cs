using AtCoderBeginnerContest164.Algorithms;
using AtCoderBeginnerContest164.Collections;
using AtCoderBeginnerContest164.Questions;
using AtCoderBeginnerContest164.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest164.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var aquired = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                var s = inputStream.ReadLine();
                aquired.Add(s);
            }

            yield return aquired.Count;
        }
    }
}
