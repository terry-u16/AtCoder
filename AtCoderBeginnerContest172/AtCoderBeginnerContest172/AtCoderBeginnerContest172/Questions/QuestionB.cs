using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest172.Algorithms;
using AtCoderBeginnerContest172.Collections;
using AtCoderBeginnerContest172.Extensions;
using AtCoderBeginnerContest172.Numerics;
using AtCoderBeginnerContest172.Questions;

namespace AtCoderBeginnerContest172.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var t = inputStream.ReadLine();
            var count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != t[i])
                {
                    count++;
                }
            }

            yield return count;
        }
    }
}
