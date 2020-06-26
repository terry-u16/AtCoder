using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu012.Algorithms;
using Kujikatsu012.Collections;
using Kujikatsu012.Extensions;
using Kujikatsu012.Numerics;
using Kujikatsu012.Questions;

namespace Kujikatsu012.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc074/tasks/abc074_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var k = inputStream.ReadInt();
            var x = inputStream.ReadIntArray();
            yield return x.Sum(xi => Math.Min(xi, k - xi) * 2);
        }
    }
}
