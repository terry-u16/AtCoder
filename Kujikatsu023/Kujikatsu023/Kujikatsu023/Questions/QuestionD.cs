using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu023.Algorithms;
using Kujikatsu023.Collections;
using Kujikatsu023.Extensions;
using Kujikatsu023.Numerics;
using Kujikatsu023.Questions;

namespace Kujikatsu023.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc081/tasks/arc081_b
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            Modular.Mod = 1000000007;

            _ = inputStream.ReadInt();
            var s = new string[2];
            for (int i = 0; i < s.Length; i++)
            {
                s[i] = inputStream.ReadLine();
            }

            var aligns = new List<Align>();
            aligns.Add(Align.None);
            for (int column = 0; column < s[0].Length; column++)
            {
                if (s[0][column] == s[1][column])
                {
                    aligns.Add(Align.Vertical);
                }
                else
                {
                    aligns.Add(Align.Horizontal);
                    column++;
                }
            }

            var count = Modular.One;

            for (int i = 1; i < aligns.Count; i++)
            {
                var factor = (aligns[i - 1], aligns[i]) switch
                {
                    (Align.Vertical, Align.Vertical) => 2,
                    (Align.Horizontal, Align.Vertical) => 1,
                    (Align.None, Align.Vertical) => 3,
                    (Align.Vertical, Align.Horizontal) => 2,
                    (Align.Horizontal, Align.Horizontal) => 3,
                    (Align.None, Align.Horizontal) => 6,
                    (_, _) => 0
                };

                count *= factor;
            }

            yield return count.Value;
        }

        enum Align
        {
            None,
            Vertical,
            Horizontal
        }
    }
}
