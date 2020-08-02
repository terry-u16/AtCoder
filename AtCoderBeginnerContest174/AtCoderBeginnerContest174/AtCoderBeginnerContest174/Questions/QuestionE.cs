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
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k) = inputStream.ReadValue<int, int>();
            var lengths = inputStream.ReadIntArray();

            yield return SearchExtensions.BoundaryBinarySearch(l => Check(l, k, lengths), 1000000000, 0);
        }

        bool Check(int maxLength, int maxCut, int[] lengths)
        {
            long totalCut = 0;
            foreach (var length in lengths)
            {
                totalCut += (length - 1) / maxLength;
            }
            return totalCut <= maxCut;
        }
    }
}
