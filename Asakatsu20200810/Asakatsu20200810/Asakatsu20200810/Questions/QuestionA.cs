using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Asakatsu20200810.Algorithms;
using Asakatsu20200810.Collections;
using Asakatsu20200810.Extensions;
using Asakatsu20200810.Numerics;
using Asakatsu20200810.Questions;

namespace Asakatsu20200810.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc086/tasks/abc086_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var ab = int.Parse(inputStream.ReadLine().Replace(" ", ""));

            for (int i = 0; i < 1000; i++)
            {
                if (i * i == ab)
                {
                    yield return "Yes";
                    yield break;
                }
            }

            yield return "No";
        }
    }
}
