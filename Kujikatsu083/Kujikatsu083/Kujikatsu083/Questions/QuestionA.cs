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
    /// https://atcoder.jp/contests/abc161/tasks/abc161_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abc = inputStream.ReadIntArray();
            (abc[0], abc[1]) = (abc[1], abc[0]);
            (abc[0], abc[2]) = (abc[2], abc[0]);
            yield return abc.Join(' ');
        }
    }
}
