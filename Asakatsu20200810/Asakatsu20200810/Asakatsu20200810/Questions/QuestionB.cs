using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Asakatsu20200810.Algorithms;
using Asakatsu20200810.Collections;
using Asakatsu20200810.Extensions;
using Asakatsu20200810.Numerics;
using Asakatsu20200810.Questions;

namespace Asakatsu20200810.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var lengths = inputStream.ReadLongArray();

            if (lengths.Any(l => l % 2 == 0))
            {
                yield return 0;
                yield break;
            }

            long min = long.MaxValue;
            for (int i = 0; i < lengths.Length; i++)
            {
                min = Math.Min(min, lengths[i] * lengths[(i + 1) % lengths.Length]);
            }

            yield return min;
        }
    }
}
