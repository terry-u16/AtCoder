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
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var a = inputStream.ReadInt();
            yield return a + a * a + a * a * a;
        }
    }
}
