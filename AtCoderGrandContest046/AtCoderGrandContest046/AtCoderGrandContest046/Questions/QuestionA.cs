using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AtCoderGrandContest046.Algorithms;
using AtCoderGrandContest046.Collections;
using AtCoderGrandContest046.Extensions;
using AtCoderGrandContest046.Numerics;
using AtCoderGrandContest046.Questions;

namespace AtCoderGrandContest046.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var x = inputStream.ReadInt();

            var current = 0;
            var count = 0;
            while (true)
            {
                count++;
                current += x;
                current %= 360;
                if (current == 0)
                {
                    break;
                }
            }

            yield return count;
        }
    }
}
