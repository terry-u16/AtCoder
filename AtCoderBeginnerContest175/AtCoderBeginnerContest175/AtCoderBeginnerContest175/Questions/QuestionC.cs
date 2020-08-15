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
using System.Numerics;

namespace AtCoderBeginnerContest175.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (x, k, d) = inputStream.ReadValue<long, long, long>();

            if (Math.Abs(x) > BigInteger.Abs(BigInteger.Multiply(k, d)))
            {
                yield return Math.Abs(x) - k * d;
            }
            else
            {
                var div = Math.Abs(x) / d;
                var mod = Math.Abs(x) % d;
                var remain = k - div;

                if (remain % 2 == 0)
                {
                    yield return mod;
                }
                else
                {
                    yield return Math.Abs(mod - d);
                }
            }
        }
    }
}
