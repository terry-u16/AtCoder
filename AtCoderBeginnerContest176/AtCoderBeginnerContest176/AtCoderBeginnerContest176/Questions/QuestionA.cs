using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest176.Algorithms;
using AtCoderBeginnerContest176.Collections;
using AtCoderBeginnerContest176.Extensions;
using AtCoderBeginnerContest176.Numerics;
using AtCoderBeginnerContest176.Questions;

namespace AtCoderBeginnerContest176.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, x, t) = inputStream.ReadValue<int, int, int>();
            yield return (n + x - 1) / x * t;
        }
    }
}
