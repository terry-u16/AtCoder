using AtCoderBeginnerContest164.Algorithms;
using AtCoderBeginnerContest164.Collections;
using AtCoderBeginnerContest164.Questions;
using AtCoderBeginnerContest164.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest164.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var multiples = new HashSet<long>(Enumerable.Range(1, 9999).Select(i => (2019L * i).ToString()).Where(s => !s.Contains('0')).Select(long.Parse));

            long count = 0;
            int[] lastMultipleCount = new int[s.Length];

            for (int index = 0; index + 5 - 1 < s.Length; index++)
            {
                for (int subLength = 5; subLength <= 12; subLength++)
                {
                    if (index + subLength - 1 < s.Length && multiples.Contains(long.Parse(s.Substring(index, subLength))))
                    {
                        count += lastMultipleCount[index] + 1;
                        if (index + subLength < s.Length)
                        {
                            lastMultipleCount[index + subLength] += lastMultipleCount[index] + 1;
                        }
                    }
                }
            }

            yield return count;
        }
    }
}
