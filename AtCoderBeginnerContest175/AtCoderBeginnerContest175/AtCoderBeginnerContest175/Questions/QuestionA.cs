using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest175.Algorithms;
using AtCoderBeginnerContest175.Collections;
using AtCoderBeginnerContest175.Extensions;
using AtCoderBeginnerContest175.Numerics;
using AtCoderBeginnerContest175.Questions;

namespace AtCoderBeginnerContest175.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var streak = 0;
            var max = 0;

            foreach (var c in s)
            {
                if (c == 'R')
                {
                    streak++;
                }
                else
                {
                    max = Math.Max(max, streak);
                    streak = 0;
                }
            }

            max = Math.Max(max, streak);

            yield return max;
        }
    }
}
