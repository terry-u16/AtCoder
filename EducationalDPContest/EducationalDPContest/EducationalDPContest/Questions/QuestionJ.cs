using EducationalDPContest.Questions;
using EducationalDPContest.Extensions;
using EducationalDPContest.Algorithms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EducationalDPContest.Questions
{
    public class QuestionJ : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var sushis = inputStream.ReadIntArray();

            yield return GetExpectedValue(sushis.Length, sushis.Count(i => i == 1), sushis.Count(i => i == 2), sushis.Count(i => i == 3));
        }

        double[,,] dpCache = new double[310, 310, 310];

        double GetExpectedValue(int all, int one, int two, int three)
        {
            if (one == 0 && two == 0 && three == 0)
            {
                return 0;
            }
            if (dpCache[one, two, three] > 0)
            {
                return dpCache[one, two, three];
            }

            double expected = all;
            if (one > 0)
            {
                expected += GetExpectedValue(all, one - 1, two, three) * one;
            }
            if (two > 0)
            {
                expected += GetExpectedValue(all, one + 1, two - 1, three) * two;
            }
            if (three > 0)
            {
                expected += GetExpectedValue(all, one, two + 1, three - 1) * three;
            }
            expected /= one + two + three;

            return dpCache[one, two, three] = expected;
        }
    }
}
