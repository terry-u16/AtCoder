using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu036.Algorithms;
using Kujikatsu036.Collections;
using Kujikatsu036.Extensions;
using Kujikatsu036.Numerics;
using Kujikatsu036.Questions;

namespace Kujikatsu036.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc159/tasks/abc159_f
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            Modular.Mod = 998244353;
            var (itemCount, sum) = inputStream.ReadValue<int, int>();
            var values = inputStream.ReadIntArray();

            var results = new Modular[itemCount + 1, sum + 1];

            var result = Modular.Zero;
            for (int item = 0; item < itemCount; item++)
            {
                results[item, 0] += 1;  // in
                for (int s = 0; s <= sum; s++)
                {
                    // 選ばない
                    results[item + 1, s] += results[item, s];

                    // 選ぶ
                    var next = s + values[item];
                    if (next <= sum)
                    {
                        results[item + 1, next] += results[item, s];
                    }
                }

                result += results[item + 1, sum];   // out
            }

            yield return result;
        }
    }
}
