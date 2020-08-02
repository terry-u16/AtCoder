using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest174.Algorithms;
using AtCoderBeginnerContest174.Collections;
using AtCoderBeginnerContest174.Extensions;
using AtCoderBeginnerContest174.Numerics;
using AtCoderBeginnerContest174.Questions;

namespace AtCoderBeginnerContest174.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var k = inputStream.ReadInt();
            var current = 7 % k;
            var count = 1;
            var found = new bool[k];
            found[current] = true;

            while (current > 0)
            {
                current = (10 * current + 7) % k;
                count++;

                if (found[current])
                {
                    yield return -1;
                    yield break;
                }
                else
                {
                    found[current] = true;
                }
            }

            yield return count;
        }
    }
}
