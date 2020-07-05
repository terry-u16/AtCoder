using System;
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
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var counter = new Counter<string>();

            for (int i = 0; i < n; i++)
            {
                var s = inputStream.ReadLine();
                counter[s]++;
            }

            yield return $"AC x {(counter["AC"])}";
            yield return $"WA x {(counter["WA"])}";
            yield return $"TLE x {(counter["TLE"])}";
            yield return $"RE x {(counter["RE"])}";
        }
    }
}
