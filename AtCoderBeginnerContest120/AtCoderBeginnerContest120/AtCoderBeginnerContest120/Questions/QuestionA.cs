﻿using AtCoderBeginnerContest120.Questions;
using AtCoderBeginnerContest120.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest120.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abc = inputStream.ReadIntArray();
            yield return Math.Min(abc[1] / abc[0], abc[2]);
        }
    }
}
