using AtCoderBeginnerContest143.Questions;
using AtCoderBeginnerContest143.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest143.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var s = "_" + inputStream.ReadLine();

            var slimes = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] != s[i + 1])
                {
                    slimes++;
                }
            }

            yield return slimes;
        }
    }
}
