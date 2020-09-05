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
    /// https://atcoder.jp/contests/sumitrust2019/tasks/sumitb2019_e
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var result = Modular.One;

            var maxs = Enumerable.Repeat(-1, 3).ToArray();

            foreach (var ai in a)
            {
                var same = maxs.Count(m => m + 1 == ai);
                result *= same;
                for (int i = 0; i < maxs.Length; i++)
                {
                    if (maxs[i] + 1 == ai)
                    {
                        maxs[i] = ai;
                        break;
                    }
                }
            }

            yield return result;
        }
    }
}
