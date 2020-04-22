using AtCoderBeginnerContest144.Questions;
using AtCoderBeginnerContest144.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest144.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();

            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    if (i * j == n)
                    {
                        yield return "Yes";
                        yield break;
                    }
                }
            }
            yield return "No";
        }
    }
}
