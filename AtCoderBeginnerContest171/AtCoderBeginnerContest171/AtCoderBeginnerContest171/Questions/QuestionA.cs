using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest171.Algorithms;
using AtCoderBeginnerContest171.Collections;
using AtCoderBeginnerContest171.Extensions;
using AtCoderBeginnerContest171.Numerics;
using AtCoderBeginnerContest171.Questions;

namespace AtCoderBeginnerContest171.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var a = inputStream.ReadLine();
            if (a == a.ToUpper())
            {
                yield return 'A';
            }
            else
            {
                yield return 'a';
            }
        }
    }
}
