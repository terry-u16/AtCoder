using Training20200528.Questions;
using Training20200528.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200528.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc062/tasks/arc062_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var ta1 = inputStream.ReadLongArray();
            var takahashi = ta1[0];
            var aoki = ta1[1];

            for (int i = 1; i < n; i++)
            {
                var ta = inputStream.ReadLongArray();
                var takahashiRatio = ta[0];
                var aokiRatio = ta[1];
                var tMinFactor = GetMinFactor(takahashi, takahashiRatio);
                var aMinFactor = GetMinFactor(aoki, aokiRatio);
                var factor = Math.Max(tMinFactor, aMinFactor);
                takahashi = takahashiRatio * factor;
                aoki = aokiRatio * factor;
            }

            yield return takahashi + aoki;
        }

        long GetMinFactor(long current, long ratio) => (current + (ratio - 1)) / ratio;
    }
}
