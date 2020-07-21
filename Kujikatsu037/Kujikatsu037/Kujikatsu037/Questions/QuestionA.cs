using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu037.Algorithms;
using Kujikatsu037.Collections;
using Kujikatsu037.Extensions;
using Kujikatsu037.Numerics;
using Kujikatsu037.Questions;

namespace Kujikatsu037.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc112/tasks/abc112_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var years = inputStream.ReadInt();
            if (years == 1)
            {
                yield return "Hello World";
            }
            else
            {
                var a = inputStream.ReadInt();
                var b = inputStream.ReadInt();
                yield return a + b;
            }
        }
    }
}
