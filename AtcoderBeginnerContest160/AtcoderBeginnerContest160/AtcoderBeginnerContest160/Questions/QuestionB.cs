using AtcoderBeginnerContest160.Questions;
using AtcoderBeginnerContest160.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtcoderBeginnerContest160.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            int x = inputStream.ReadInt();
            int coin500 = x / 500;
            int coin5 = (x % 500) / 5;

            yield return coin500 * 1000 + coin5 * 5;
        }
    }
}
