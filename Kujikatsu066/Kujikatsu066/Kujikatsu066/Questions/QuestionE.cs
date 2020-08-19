using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu066.Algorithms;
using Kujikatsu066.Collections;
using Kujikatsu066.Extensions;
using Kujikatsu066.Numerics;
using Kujikatsu066.Questions;

namespace Kujikatsu066.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc135/tasks/abc135_d
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            const int Mod = 13;
            var counts = new Modular[s.Length + 1, Mod];
            counts[0, 0] = 1;

            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (c != '?')
                {
                    c -= '0';
                    Proceed(Mod, counts, i, c);
                }
                else
                {
                    for (int value = 0; value < 10; value++)
                    {
                        Proceed(Mod, counts, i, value);
                    }
                }
            }

            yield return counts[s.Length, 5];
        }

        private static void Proceed(int Mod, Modular[,] counts, int i, int current)
        {
            for (int lastMod = 0; lastMod < Mod; lastMod++)
            {
                var nextMod = (lastMod * 10 + current) % Mod;
                counts[i + 1, nextMod] += counts[i, lastMod];
            }
        }
    }
}
