﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest173.Algorithms;
using AtCoderBeginnerContest173.Collections;
using AtCoderBeginnerContest173.Extensions;
using AtCoderBeginnerContest173.Numerics;
using AtCoderBeginnerContest173.Questions;

namespace AtCoderBeginnerContest173.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            yield return (100000 - n) % 1000;
        }
    }
}
