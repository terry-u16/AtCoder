﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu057.Algorithms;
using Kujikatsu057.Collections;
using Kujikatsu057.Extensions;
using Kujikatsu057.Numerics;
using Kujikatsu057.Questions;

namespace Kujikatsu057.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc120/tasks/abc120_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (a, b, c) = inputStream.ReadValue<int, int, int>();
            yield return Math.Min(b / a, c);
        }
    }
}
