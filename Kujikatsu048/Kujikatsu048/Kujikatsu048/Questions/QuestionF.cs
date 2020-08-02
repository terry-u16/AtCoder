using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu048.Algorithms;
using Kujikatsu048.Collections;
using Kujikatsu048.Extensions;
using Kujikatsu048.Numerics;
using Kujikatsu048.Questions;

namespace Kujikatsu048.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/jsc2019-qual/tasks/jsc2019_qual_d
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var levels = new int[n][];
            for (int i = 0; i < levels.Length; i++)
            {
                levels[i] = new int[n];
            }

            var cycle = n % 2 == 0 ? n - 1 : n;
            var level = 1;
            for (int step = 1; step <= cycle / 2; step++)
            {
                for (int i = 0; i < cycle - 1; i++)
                {
                    levels[step * i % cycle][step * (i + 1) % cycle] = level;
                    levels[step * (i + 1) % cycle][step * i % cycle] = level;
                }
                level++;
            }

            for (int i = level; i < cycle; i++)
            {
                levels[0][i] = level;
                levels[i][0] = level;
            }

            level++;

            if (n % 2 == 0)
            {
                for (int i = 0; i < cycle; i++)
                {
                    levels[n - 1][i] = level;
                    levels[i][n - 1] = level;
                }
            }

            for (int i = 0; i < levels.Length - 1; i++)
            {
                yield return levels[i].Skip(i + 1).Join(' ');
            }
        }
    }
}
