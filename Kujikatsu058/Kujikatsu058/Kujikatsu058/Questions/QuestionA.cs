using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu058.Algorithms;
using Kujikatsu058.Collections;
using Kujikatsu058.Extensions;
using Kujikatsu058.Numerics;
using Kujikatsu058.Questions;

namespace Kujikatsu058.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc111/tasks/abc111_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();

            while (true)
            {
                var s = n.ToString();
                if (s[0] == s[1] && s[1] == s[2])
                {
                    yield return n;
                    yield break;
                }

                n++;
            }
        }
    }
}
