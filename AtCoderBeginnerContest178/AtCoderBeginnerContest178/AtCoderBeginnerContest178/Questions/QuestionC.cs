using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest178.Algorithms;
using AtCoderBeginnerContest178.Collections;
using AtCoderBeginnerContest178.Extensions;
using AtCoderBeginnerContest178.Numerics;
using AtCoderBeginnerContest178.Questions;

namespace AtCoderBeginnerContest178.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();

            var a = Modular.One;
            var b = Modular.One;
            var c = Modular.One;

            for (int i = 0; i < n; i++)
            {
                a *= 10;
                b *= 9;
                c *= 8;
            }

            yield return a - 2 * b + c;
        }
    }
}
