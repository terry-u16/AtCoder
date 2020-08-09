using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200809.Algorithms;
using Training20200809.Collections;
using Training20200809.Extensions;
using Training20200809.Numerics;
using Training20200809.Questions;

namespace Training20200809.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc071/tasks/arc081_a
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();

            for (char c = 'a'; c <= 'z'; c++)
            {
                if (!s.Any(si => si == c))
                {
                    yield return c;
                    yield break;
                }
            }

            yield return "None";
        }
    }
}
