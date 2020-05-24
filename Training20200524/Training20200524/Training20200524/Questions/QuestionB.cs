using Training20200524.Questions;
using Training20200524.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200524.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/pakencamp-2019-day3/tasks/pakencamp_2019_day3_c
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var people = nm[0];
            var songs = nm[1];

            var scores = new long[people][];
            for (int i = 0; i < people; i++)
            {
                scores[i] = inputStream.ReadLongArray();
            }
            yield return GetMaximumScore(scores);
        }

        long GetMaximumScore(long[][] scores)
        {
            var people = scores.Length;
            var songs = scores[0].Length;

            long maxScore = 0;
            for (int song1 = 0; song1 < songs; song1++)
            {
                for (int song2 = song1 + 1; song2 < songs; song2++)
                {
                    long total = Enumerable.Range(0, people).Sum(i => Math.Max(scores[i][song1], scores[i][song2]));
                    maxScore = Math.Max(maxScore, total);
                }
            }
            return maxScore;
        }
    }
}
