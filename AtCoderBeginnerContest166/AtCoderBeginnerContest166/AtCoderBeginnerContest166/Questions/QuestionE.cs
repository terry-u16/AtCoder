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
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var heights = inputStream.ReadIntArray();
            var counter = new Counter<int>();

            for (int i = 0; i < heights.Length; i++)
            {
                var height = heights[i] - i;
                counter[height]++;
            }

            long pairs = 0;
            for (int i = 0; i < heights.Length - 1; i++)
            {
                var opponent = -(heights[i] + i);
                pairs += counter[opponent];
                counter[heights[i] - i]--;
            }

            yield return pairs;
        }
    }
}
