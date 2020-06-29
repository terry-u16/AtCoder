using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu015.Algorithms;
using Kujikatsu015.Collections;
using Kujikatsu015.Extensions;
using Kujikatsu015.Numerics;
using Kujikatsu015.Questions;

namespace Kujikatsu015.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/code-festival-2017-quala/tasks/code_festival_2017_quala_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            yield return s.StartsWith("YAKI") ? "Yes" : "No";
        }
    }
}
