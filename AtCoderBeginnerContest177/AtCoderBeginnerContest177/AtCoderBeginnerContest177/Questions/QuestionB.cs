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
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var t = inputStream.ReadLine();

            var min = int.MaxValue;

            for (int offset = 0; offset <= s.Length - t.Length; offset++)
            {
                var count = 0;
                for (int i = 0; i < t.Length; i++)
                {
                    if (s[offset + i] != t[i])
                    {
                        count++;
                    }
                }
                min = Math.Min(min, count);
            }

            yield return min;
        }
    }
}
