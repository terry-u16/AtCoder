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
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (obseravtoryCount, wayCount) = inputStream.ReadValue<int, int>();
            var heights = inputStream.ReadIntArray();
            var isGoodObservtory = Enumerable.Repeat(true, obseravtoryCount).ToArray();

            for (int i = 0; i < wayCount; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                a--;
                b--;
                var compared = heights[a].CompareTo(heights[b]);
                if (compared > 0)
                {
                    isGoodObservtory[b] = false;
                }
                else if (compared < 0)
                {
                    isGoodObservtory[a] = false;
                }
                else
                {
                    isGoodObservtory[a] = false;
                    isGoodObservtory[b] = false;
                }
            }

            yield return isGoodObservtory.Count(b => b);
        }
    }
}
