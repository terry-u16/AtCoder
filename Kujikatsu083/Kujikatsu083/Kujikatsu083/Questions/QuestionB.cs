using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu083.Algorithms;
using Kujikatsu083.Collections;
using Kujikatsu083.Extensions;
using Kujikatsu083.Numerics;
using Kujikatsu083.Questions;

namespace Kujikatsu083.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc027/tasks/agc027_a
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (_, candies) = inputStream.ReadValue<int, int>();
            var neededs = inputStream.ReadIntArray();
            Array.Sort(neededs);

            var happy = 0;
            var remain = candies;

            foreach (var needed in neededs)
            {
                if (remain < needed)
                {
                    yield return happy;
                    yield break;
                }
                happy++;
                remain -= needed;
            }

            if (remain > 0)
            {
                happy--;
            }

            yield return happy;
        }
    }
}
