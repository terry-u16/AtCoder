using AtCoderBeginnerContest126.Questions;
using AtCoderBeginnerContest126.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest126.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadIntArray();
            var n = nk[0];
            var criteria = nk[1];

            double totalProbability = 0;
            for (int dice = 1; dice <= n; dice++)
            {
                var score = dice;
                var probability = 1.0 / n;

                while (score < criteria)
                {
                    score *= 2;
                    probability /= 2;
                }
                totalProbability += probability;
            }

            yield return totalProbability;
        }
    }
}
