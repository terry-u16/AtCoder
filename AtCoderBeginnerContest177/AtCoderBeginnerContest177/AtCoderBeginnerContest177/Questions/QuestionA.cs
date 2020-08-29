using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest177.Algorithms;
using AtCoderBeginnerContest177.Collections;
using AtCoderBeginnerContest177.Extensions;
using AtCoderBeginnerContest177.Numerics;
using AtCoderBeginnerContest177.Questions;

namespace AtCoderBeginnerContest177.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (d, t, s) = inputStream.ReadValue<int, int, int>();

            if ((d + s - 1) / s <= t)
            {
                yield return "Yes";
            }
            else
            {
                yield return "No";
            }
        }
    }
}
