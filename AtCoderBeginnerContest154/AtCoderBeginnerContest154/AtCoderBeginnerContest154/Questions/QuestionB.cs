﻿using AtCoderBeginnerContest154.Questions;
using AtCoderBeginnerContest154.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest154.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            yield return string.Concat(Enumerable.Repeat('x', inputStream.ReadLine().Length));
        }
    }
}
