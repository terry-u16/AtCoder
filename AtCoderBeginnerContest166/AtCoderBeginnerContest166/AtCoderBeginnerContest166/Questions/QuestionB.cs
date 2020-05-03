using AtCoderBeginnerContest166.Algorithms;
using AtCoderBeginnerContest166.Collections;
using AtCoderBeginnerContest166.Questions;
using AtCoderBeginnerContest166.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest166.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k) = inputStream.ReadValue<int, int>();
            var allSunuke = new HashSet<int>(Enumerable.Range(1, n));
            var okashiSunuke = new HashSet<int>();

            for (int i = 0; i < k; i++)
            {
                _ = inputStream.ReadInt();
                foreach (var sunuke in inputStream.ReadIntArray())
                {
                    okashiSunuke.Add(sunuke);
                }
            }

            yield return allSunuke.Except(okashiSunuke).Count();
        }
    }
}
