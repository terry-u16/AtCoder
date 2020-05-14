using AtCoderBeginnerContest117.Algorithms;
using AtCoderBeginnerContest117.Collections;
using AtCoderBeginnerContest117.Questions;
using AtCoderBeginnerContest117.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest117.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (_, maxX) = inputStream.ReadValue<int, long>();
            var a = inputStream.ReadLongArray();

            var fMax = new long[41, 2].SetAll((_, __) => long.MinValue);
            const int EqualOrOver = 0;
            const int Under = 1;

            fMax[40, 0] = 0;
            for (int digit = 39; digit >= 0; digit--)
            {
                long mask = 1L << digit;
                var ones = a.Count(ai => (ai & mask) > 0);

                if ((maxX & mask) > 0)
                {
                    // Eq -> Eq (di == 1)
                    AlgorithmHelpers.UpdateWhenLarge(ref fMax[digit, EqualOrOver], fMax[digit + 1, EqualOrOver] + mask * (a.Length - ones));
                    // Eq -> Under (di == 0)
                    AlgorithmHelpers.UpdateWhenLarge(ref fMax[digit, Under], fMax[digit + 1, EqualOrOver] + mask * ones);
                }
                else
                {
                    // Eq -> Eq (di == 0)
                    AlgorithmHelpers.UpdateWhenLarge(ref fMax[digit, EqualOrOver], fMax[digit + 1, EqualOrOver] + mask * ones);
                }

                // Under -> Under
                AlgorithmHelpers.UpdateWhenLarge(ref fMax[digit, Under], fMax[digit + 1, Under] + mask * ones);
                AlgorithmHelpers.UpdateWhenLarge(ref fMax[digit, Under], fMax[digit + 1, Under] + mask * (a.Length - ones));
            }

            yield return Math.Max(fMax[0, EqualOrOver], fMax[0, Under]);
        }
    }
}
