using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu053.Algorithms;
using Kujikatsu053.Collections;
using Kujikatsu053.Extensions;
using Kujikatsu053.Numerics;
using Kujikatsu053.Questions;

namespace Kujikatsu053.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc115/tasks/abc115_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var d = inputStream.ReadInt();
            var result = "Christmas";

            while (d < 25)
            {
                result += " Eve";
                d++;
            }

            yield return result;
        }
    }
}
