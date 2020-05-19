using PAST002.Algorithms;
using PAST002.Collections;
using PAST002.Questions;
using PAST002.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PAST002.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();

            yield return string.Join(" ", Enumerable.Range(1, n).Select(i => GetCount(a, i)));
        }

        int GetCount(int[] a, int i)
        {
            var current = i;
            for (int j = 1; true; j++)
            {
                current = a[current - 1];
                if (current == i)
                {
                    return j;
                }
            }
        }
    }
}
