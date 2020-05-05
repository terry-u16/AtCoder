using AtCoderBeginnerContest125.Questions;
using AtCoderBeginnerContest125.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest125.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var values = inputStream.ReadIntArray();
            var costs = inputStream.ReadIntArray();

            var max = int.MinValue;
            for (int flag = 0; flag < 1 << n; flag++)
            {
                var current = 0;

                for (int jewel = 0; jewel < n; jewel++)
                {
                    if ((flag & (1 << jewel)) > 0)
                    {
                        current += values[jewel] - costs[jewel];
                    }
                }
                max = Math.Max(max, current);
            }

            yield return max;
        }
    }
}
