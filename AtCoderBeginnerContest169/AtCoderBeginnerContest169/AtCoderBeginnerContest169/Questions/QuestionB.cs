using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using AtCoderBeginnerContest169.Algorithms;
using AtCoderBeginnerContest169.Collections;
using AtCoderBeginnerContest169.Extensions;
using AtCoderBeginnerContest169.Numerics;
using AtCoderBeginnerContest169.Questions;

namespace AtCoderBeginnerContest169.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var a = inputStream.ReadLongArray();
            var mul = new BigInteger(1);
            if (a.Contains(0))
            {
                yield return 0;
                yield break;
            }

            foreach (var ai in a)
            {
                mul *= ai;
                if (mul > 100_0000_0000_0000_0000L)
                {
                    yield return -1;
                    yield break;
                }
            }

            yield return mul;
        }
    }
}
