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
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, sum) = inputStream.ReadValue<int, int>();
            var a = inputStream.ReadIntArray();
            const int mod = 998244353;

            var modCount = new Modular[n + 1, sum + 1];
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= sum; j++)
                {
                    modCount[i, j] = new Modular(0, mod);
                }
            }

            modCount[0, 0] = new Modular(1, mod);

            for (int i = 0; i < n; i++)
            {
                var ai = a[i];
                for (int s = 0; s <= sum; s++)
                {
                    // 使う場合
                    if (s + ai <= sum)
                    {
                        modCount[i + 1, s + ai] += modCount[i, s];
                    }

                    // 使わない場合
                    modCount[i + 1, s] += modCount[i, s] * new Modular(2, mod);
                }
            }

            yield return modCount[n, sum].Value;
        }
    }
}
