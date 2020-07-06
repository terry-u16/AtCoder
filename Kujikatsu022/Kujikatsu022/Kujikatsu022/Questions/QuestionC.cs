using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu022.Algorithms;
using Kujikatsu022.Collections;
using Kujikatsu022.Extensions;
using Kujikatsu022.Numerics;
using Kujikatsu022.Questions;

namespace Kujikatsu022.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc034/tasks/agc034_a
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (_, snukeStart, fnukeStart, snukeGoal, fnukeGoal) = inputStream.ReadValue<int, int, int, int, int>();
            snukeStart--;
            fnukeStart--;
            snukeGoal--;
            fnukeGoal--;
            var s = inputStream.ReadLine() + "#####";

            var ok = true;

            for (int i = Math.Min(snukeStart, fnukeStart); i < Math.Max(snukeGoal, fnukeGoal); i++)
            {
                if (s[i] == '#' && s[i + 1] == '#')
                {
                    ok = false;
                    break;
                }
            }

            if ((long)(snukeStart - fnukeStart) * (snukeGoal - fnukeGoal) < 0)
            {
                var localOk = false;
                for (int i = Math.Max(snukeStart, fnukeStart); i <= Math.Min(snukeGoal, fnukeGoal); i++)
                {
                    if (s[i - 1] == '.' && s[i] == '.' && s[i + 1] == '.')
                    {
                        localOk = true;
                        break;
                    }
                }
                ok &= localOk;
            }

            yield return ok ? "Yes" : "No";
        }
    }
}
