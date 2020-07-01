using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu017.Algorithms;
using Kujikatsu017.Collections;
using Kujikatsu017.Extensions;
using Kujikatsu017.Numerics;
using Kujikatsu017.Questions;
using System.Numerics;

namespace Kujikatsu017.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc059/tasks/abc059_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var a = BigInteger.Parse(inputStream.ReadLine());
            var b = BigInteger.Parse(inputStream.ReadLine());

            if (a > b)
            {
                yield return "GREATER";
            }
            else if (a < b)
            {
                yield return "LESS";
            }
            else
            {
                yield return "EQUAL";
            }
        }
    }
}
