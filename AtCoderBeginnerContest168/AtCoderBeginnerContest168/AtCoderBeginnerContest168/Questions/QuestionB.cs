using AtCoderBeginnerContest168.Algorithms;
using AtCoderBeginnerContest168.Collections;
using AtCoderBeginnerContest168.Questions;
using AtCoderBeginnerContest168.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest168.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var k = inputStream.ReadInt();
            var s = inputStream.ReadLine();
            if (s.Length <= k)
            {
                yield return s;
            }
            else
            {
                yield return s.Substring(0, k) + "...";
            }
        }
    }
}
