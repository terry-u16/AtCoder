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
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var counts = new Dictionary<char, int>();
            for (char c = 'a'; c <= 'c'; c++)
            {
                counts[c] = 0;
            }

            foreach (var c in s)
            {
                counts[c]++;
            }

            yield return counts.First(p => p.Value == counts.Max(p => p.Value)).Key;
        }
    }
}
