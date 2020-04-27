using AtCoderBeginnerContest136.Questions;
using AtCoderBeginnerContest136.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest136.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var lastChildrenCount = new int[s.Length];

            var lastIndex = -1;
            var streak = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'L')
                {
                    if (streak == 0)
                    {
                        lastIndex = i;
                    }

                    streak++;
                    var index = streak % 2 == 1 ? lastIndex : lastIndex - 1;
                    lastChildrenCount[index]++;
                }
                else
                {
                    streak = 0;
                }
            }

            streak = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == 'R')
                {
                    if (streak == 0)
                    {
                        lastIndex = i;
                    }

                    streak++;
                    var index = streak % 2 == 1 ? lastIndex : lastIndex + 1;
                    lastChildrenCount[index]++;
                }
                else
                {
                    streak = 0;
                }
            }

            yield return string.Join(" ", lastChildrenCount);
        }
    }
}
