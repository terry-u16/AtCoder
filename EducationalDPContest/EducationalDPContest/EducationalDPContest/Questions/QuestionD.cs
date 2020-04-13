using EducationalDPContest.Questions;
using EducationalDPContest.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EducationalDPContest.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nw = inputStream.ReadIntArray();
            var n = nw[0];
            var capacity = nw[1];

            var dpValues = new long[n + 1, capacity + 1];
            
            for (int i = 1; i <= n; i++)
            {
                var wv = inputStream.ReadIntArray();
                var w = wv[0];
                var v = wv[1];

                for (int maxWeight = 0; maxWeight <= capacity; maxWeight++)
                {
                    // 選んだとき
                    if (maxWeight - w >= 0)
                    {
                        dpValues[i, maxWeight] = Math.Max(dpValues[i, maxWeight], dpValues[i - 1, maxWeight - w] + v);
                    }

                    // 選ばないとき
                    dpValues[i, maxWeight] = Math.Max(dpValues[i, maxWeight], dpValues[i - 1, maxWeight]);
                }
            }

            yield return dpValues[n, capacity];
        }
    }
}
