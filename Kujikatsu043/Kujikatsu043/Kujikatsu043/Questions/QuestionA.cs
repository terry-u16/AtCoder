using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu043.Algorithms;
using Kujikatsu043.Collections;
using Kujikatsu043.Extensions;
using Kujikatsu043.Numerics;
using Kujikatsu043.Questions;

namespace Kujikatsu043.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (r, g, b) = inputStream.ReadValue<int, int, int>();
            var a = r * 100 + g * 10 + b;
            yield return a % 4 == 0 ? "YES" : "NO";
        }
    }
}
