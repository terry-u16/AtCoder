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
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadLine();
            var sum = 0;

            foreach (var c in n)
            {
                sum += c - '0';
            }

            yield return sum % 9 == 0 ? "Yes" : "No";
        }
    }
}
