using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AtCoderBeginnerContest169.Algorithms;
using AtCoderBeginnerContest169.Collections;
using AtCoderBeginnerContest169.Extensions;
using AtCoderBeginnerContest169.Numerics;
using AtCoderBeginnerContest169.Questions;

namespace AtCoderBeginnerContest169.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var min = new long[n];
            var max = new long[n];

            for (int i = 0; i < min.Length; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                min[i] = a;
                max[i] = b;
            }

            Array.Sort(min);
            Array.Sort(max);

            if (n % 2 == 0)
            {
                var minMedianDoubled = min[n / 2 - 1] + min[n / 2];
                var maxMedianDoubled = max[n / 2 - 1] + max[n / 2];
                yield return maxMedianDoubled - minMedianDoubled + 1;
            }
            else
            {
                var minMedian = min[n / 2];
                var maxMedian = max[n / 2];
                yield return maxMedian - minMedian + 1;
            }
        }
    }
}
