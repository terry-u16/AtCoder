using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderGrandContest047.Algorithms;
using AtCoderGrandContest047.Collections;
using AtCoderGrandContest047.Extensions;
using AtCoderGrandContest047.Numerics;
using AtCoderGrandContest047.Questions;

namespace AtCoderGrandContest047.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            long zeros = 0;
            const int MaxDenominator = 1_000_000_000;
            const int TwoFiveMax = 13 * 2;
            const int Criteria = 9 * 2;
            var twoFives = new long[TwoFiveMax + 1, TwoFiveMax + 1];

            for (int i = 0; i < n; i++)
            {
                var a = inputStream.ReadValue<decimal>();
                var toAdd = (long)(a * MaxDenominator);
                if (toAdd == 0)
                {
                    zeros++;
                }
                else
                {
                    var two = 0;
                    var five = 0;
                    while (toAdd % 2 == 0 && two < TwoFiveMax)
                    {
                        two++;
                        toAdd /= 2;
                    }

                    while (toAdd % 5 == 0 && five < TwoFiveMax)
                    {
                        five++;
                        toAdd /= 5;
                    }

                    twoFives[two, five]++;
                }
            }

            long result = 0;

            for (int two = 0; two <= TwoFiveMax; two++)
            {
                for (int five = 0; five <= TwoFiveMax; five++)
                {
                    for (int otherTwo = Math.Max(Criteria - two, 0); otherTwo <= TwoFiveMax; otherTwo++)
                    {
                        for (int otherFive = Math.Max(Criteria - five, 0); otherFive <= TwoFiveMax; otherFive++)
                        {
                            if (two == otherTwo && five == otherFive)
                            {
                                continue;
                            }

                            result += twoFives[two, five] * twoFives[otherTwo, otherFive];
                        }
                    }
                }
            }

            result /= 2;

            for (int i = 0; i < zeros; i++)
            {
                result += n - i - 1;
            }

            for (int two = 0; two <= TwoFiveMax; two++)
            {
                for (int five = 0; five <= TwoFiveMax; five++)
                {
                    if (two * 2 >= Criteria && five * 2 >= Criteria)
                    {
                        result += twoFives[two, five] * (twoFives[two, five] - 1) / 2;
                    }
                }
            }

            yield return result;
        }
    }
}
