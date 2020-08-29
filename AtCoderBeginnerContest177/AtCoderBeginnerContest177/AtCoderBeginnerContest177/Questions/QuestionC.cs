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
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var sum = Modular.Zero;
            var result = Modular.Zero;

            foreach (var ai in a)
            {
                sum += ai;
            }

            foreach (var ai in a)
            {
                sum -= ai;
                result += ai * sum;
            }

            yield return result;
        }
    }
}
