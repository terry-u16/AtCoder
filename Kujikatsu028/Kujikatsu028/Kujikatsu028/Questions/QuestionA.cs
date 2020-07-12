using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu028.Algorithms;
using Kujikatsu028.Collections;
using Kujikatsu028.Extensions;
using Kujikatsu028.Numerics;
using Kujikatsu028.Questions;

namespace Kujikatsu028.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc051/tasks/abc051_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            yield return inputStream.ReadLine().Replace(',', ' ');
        }
    }
}
