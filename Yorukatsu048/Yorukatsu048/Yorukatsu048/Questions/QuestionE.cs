using Yorukatsu048.Questions;
using Yorukatsu048.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu048.Questions
{
    /// <summary>
    /// ARC074 C
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var hw = inputStream.ReadIntArray();
            long height = hw[0];
            long width = hw[1];

            long min = Math.Min(Math.Min(Math.Min(GetDiff3(height, width), GetDiff3(width, height)), GetDiff2And1(height, width)), GetDiff2And1(width, height));
            yield return min;
        }

        long GetDiff3(long height, long width)
        {
            long min = long.MaxValue;
            for (int i = 1; i * 2 < height; i++)
            {
                min = Math.Min(min, Math.Abs(i - (height - 2 * i)) * width);
            }
            return min;
        }

        long GetDiff2And1(long height, long width)
        {
            long overallMin = long.MaxValue;
            for (int i = 0; i < height; i++)
            {
                var s1 = i * width;
                var w2 = width / 2;
                var w3 = width - w2;
                var h = height - i;
                var s2 = w2 * h;
                var s3 = w3 * h;
                var max = Math.Max(s1, Math.Max(s2, s3));
                var min = Math.Min(s1, Math.Min(s2, s3));
                overallMin = Math.Min(overallMin, max - min);
            }
            return overallMin;
        }
    }
}
