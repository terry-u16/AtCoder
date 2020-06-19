using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Kujikatsu005.Algorithms;
using Kujikatsu005.Collections;
using Kujikatsu005.Extensions;
using Kujikatsu005.Numerics;
using Kujikatsu005.Questions;

namespace Kujikatsu005.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc134/tasks/abc134_e
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var maxValues = Enumerable.Repeat(-1, 100_000).ToArray();

            for (int i = 0; i < n; i++)
            {
                var a = inputStream.ReadInt();
                var index = SearchExtensions.GetLessThanIndex(maxValues, a);
                maxValues[index] = a;
            }

            yield return maxValues.Count(i => i >= 0);
        }
    }
}
