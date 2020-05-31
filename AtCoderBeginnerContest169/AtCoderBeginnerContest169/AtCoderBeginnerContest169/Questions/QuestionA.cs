using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AtCoderBeginnerContest169.Algorithms;
using AtCoderBeginnerContest169.Collections;
using AtCoderBeginnerContest169.Extensions;
using AtCoderBeginnerContest169.Numerics;
using AtCoderBeginnerContest169.Questions;

namespace AtCoderBeginnerContest169.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (a, b) = inputStream.ReadValue<int, int>();
            yield return a * b;
        }
    }
}
