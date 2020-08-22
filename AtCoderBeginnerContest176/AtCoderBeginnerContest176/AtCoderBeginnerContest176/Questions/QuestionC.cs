using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest176.Algorithms;
using AtCoderBeginnerContest176.Collections;
using AtCoderBeginnerContest176.Extensions;
using AtCoderBeginnerContest176.Numerics;
using AtCoderBeginnerContest176.Questions;

namespace AtCoderBeginnerContest176.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var heights = inputStream.ReadLongArray();

            var lastHeight = 0L;
            long total = 0;

            foreach (var h in heights)
            {
                if (lastHeight > h)
                {
                    var step = lastHeight - h;
                    total += step;
                }
                else
                {
                    lastHeight = h;
                }
            }

            yield return total;
        }
    }
}
