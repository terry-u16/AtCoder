using PAST002.Algorithms;
using PAST002.Collections;
using PAST002.Questions;
using PAST002.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PAST002.Questions
{
    public class QuestionK : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var s = inputStream.ReadLine();
            var reverseCosts = inputStream.ReadLongArray();
            var eraseCosts = inputStream.ReadLongArray();
            const long Inf = 1L << 60;

            var costs = new long[s.Length + 1, s.Length + 1].SetAll((i, j) => Inf);
            costs[0, 0] = 0;

            for (int cursor = 0; cursor < s.Length; cursor++)
            {
                for (int height = 0; height < s.Length; height++)
                {
                    var bracket = s[cursor] == '(' ? 1 : -1;

                    // do nothing
                    if (height + bracket >= 0)
                    {
                        AlgorithmHelpers.UpdateWhenSmall(ref costs[cursor + 1, height + bracket], costs[cursor, height]);
                    }

                    // reverse
                    if (height - bracket >= 0)
                    {
                        AlgorithmHelpers.UpdateWhenSmall(ref costs[cursor + 1, height - bracket], costs[cursor, height] + reverseCosts[cursor]);
                    }

                    // erase
                    AlgorithmHelpers.UpdateWhenSmall(ref costs[cursor + 1, height], costs[cursor, height] + eraseCosts[cursor]);
                }
            }

            yield return costs[s.Length, 0];
        }
    }
}
