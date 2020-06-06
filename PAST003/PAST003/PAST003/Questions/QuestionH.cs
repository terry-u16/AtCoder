using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PAST003.Algorithms;
using PAST003.Collections;
using PAST003.Extensions;
using PAST003.Numerics;
using PAST003.Questions;

namespace PAST003.Questions
{
    public class QuestionH : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (hurdlesCount, length) = inputStream.ReadValue<int, int>();
            var hardles = inputStream.ReadIntArray();
            var (t1, t2, t3) = inputStream.ReadValue<int, int, int>();

            var fastestTime = Enumerable.Repeat(1L << 50, length + 1).ToArray();
            fastestTime[0] = 0;

            for (int i = 0; i < length; i++)
            {
                var loss = Array.BinarySearch(hardles, i) >= 0 ? t3 : 0;

                // 走る
                AlgorithmHelpers.UpdateWhenSmall(ref fastestTime[i + 1], fastestTime[i] + t1 + loss);

                // 1飛ぶ
                if (i + 2 <= length)
                {
                    AlgorithmHelpers.UpdateWhenSmall(ref fastestTime[i + 2], fastestTime[i] + t1 + t2 + loss);
                }
                else
                {
                    AlgorithmHelpers.UpdateWhenSmall(ref fastestTime[i + 1], fastestTime[i] + (t1 + t2) / 2 + loss);
                }

                // 3飛ぶ
                if (i + 4 <= length)
                {
                    AlgorithmHelpers.UpdateWhenSmall(ref fastestTime[i + 4], fastestTime[i] + t1 + t2 * 3 + loss);
                }
                else
                {
                    var toJumpDoubled = length * 2 - i * 2 - 1;
                    AlgorithmHelpers.UpdateWhenSmall(ref fastestTime[length], fastestTime[i] + (t1 + toJumpDoubled * t2) / 2 + loss);
                }
            }

            yield return fastestTime[length];
        }
    }
}
