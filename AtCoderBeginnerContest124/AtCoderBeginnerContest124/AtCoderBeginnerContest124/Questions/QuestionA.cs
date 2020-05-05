using AtCoderBeginnerContest124.Questions;
using AtCoderBeginnerContest124.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest124.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var ab = inputStream.ReadIntArray();

            var coins = 0;
            for (int i = 0; i < 2; i++)
            {
                if (ab[0] > ab[1])
                {
                    coins += ab[0];
                    ab[0] -= 1;
                }
                else
                {
                    coins += ab[1];
                    ab[1] -= 1;
                }
            }

            yield return coins;
        }
    }
}
