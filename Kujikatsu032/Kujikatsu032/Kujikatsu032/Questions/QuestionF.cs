using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu032.Algorithms;
using Kujikatsu032.Collections;
using Kujikatsu032.Extensions;
using Kujikatsu032.Numerics;
using Kujikatsu032.Questions;

namespace Kujikatsu032.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc158/tasks/abc158_e
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, p) = inputStream.ReadValue<int, int>();
            var s = inputStream.ReadLine();

            if (p == 2 || p == 5)
            {
                long answer = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if ((s[i] - '0') % p == 0)
                    {
                        answer += i + 1;
                    }
                }

                yield return answer;
            }
            else
            {
                Modular.Mod = p;
                var mods = new Modular[n + 1];
                var tenFactor = Modular.One;

                for (int i = s.Length - 1; i >= 0; i--)
                {
                    mods[i] = mods[i + 1] + (s[i] - '0') * tenFactor;
                    tenFactor *= 10;
                }

                var counter = new long[p];

                foreach (var mod in mods)
                {
                    counter[mod.Value]++;
                }

                long answer = 0;

                foreach (var count in counter)
                {
                    answer += count * (count - 1) / 2;
                }

                yield return answer;
            }
        }
    }
}
