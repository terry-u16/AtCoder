﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu078.Algorithms;
using Kujikatsu078.Collections;
using Kujikatsu078.Extensions;
using Kujikatsu078.Numerics;
using Kujikatsu078.Questions;

namespace Kujikatsu078.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var k = inputStream.ReadInt();
            var odds = (k + 1) / 2;
            var evens = k / 2;
            yield return odds * evens;
        }
    }
}
