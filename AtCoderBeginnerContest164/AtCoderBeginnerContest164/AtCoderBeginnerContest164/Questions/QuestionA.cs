﻿using AtCoderBeginnerContest164.Algorithms;
using AtCoderBeginnerContest164.Collections;
using AtCoderBeginnerContest164.Questions;
using AtCoderBeginnerContest164.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest164.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (sheeps, wolves) = inputStream.ReadValue<int, int>();
            yield return wolves >= sheeps ? "unsafe" : "safe";
        }
    }
}
