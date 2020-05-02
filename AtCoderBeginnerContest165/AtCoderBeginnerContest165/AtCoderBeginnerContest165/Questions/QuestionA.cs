using AtCoderBeginnerContest165.Algorithms;
using AtCoderBeginnerContest165.Collections;
using AtCoderBeginnerContest165.Questions;
using AtCoderBeginnerContest165.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest165.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var k = inputStream.ReadInt();
            var (a, b) = inputStream.ReadValue<int, int>();

            for (int i = 1; i * k <= b; i++)
            {
                if (i * k >= a && i * k <= b)
                {
                    yield return "OK";
                    yield break;
                }
            }

            yield return "NG";
        }
    }
}
