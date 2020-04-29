using Yorukatsu028.Questions;
using Yorukatsu028.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu028.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nx = inputStream.ReadIntArray();
            var n = nx[0];
            var candyCriteria = nx[1];

            var candyCounts = inputStream.ReadIntArray();
            long totalEaten = 0;

            for (int i = 0; i < candyCounts.Length - 1; i++)
            {
                var over = candyCounts[i] + candyCounts[i + 1] - candyCriteria;
                
                if (over > 0)
                {
                    totalEaten += over;
                    if (over > candyCounts[i + 1])
                    {
                        candyCounts[i] -= over - candyCounts[i + 1];
                        candyCounts[i + 1] = 0;
                    }
                    else
                    {
                        candyCounts[i + 1] -= over;
                    }
                }
            }

            yield return totalEaten;
        }
    }
}
