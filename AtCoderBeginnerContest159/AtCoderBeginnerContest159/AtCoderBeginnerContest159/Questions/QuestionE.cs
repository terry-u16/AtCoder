using AtCoderBeginnerContest159.Questions;
using AtCoderBeginnerContest159.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest159.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        int h, w, k;
        bool[][] isWhite;

        // 復習
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var hwk = inputStream.ReadIntArray();
            h = hwk[0];
            w = hwk[1];
            k = hwk[2];

            isWhite = new bool[h][];
            for (int i = 0; i < h; i++)
            {
                isWhite[i] = inputStream.ReadLine().Select(c => c == '1').ToArray();
            }

            int min = int.MaxValue;
            for (int bitFlag = 0; bitFlag < 1 << (h - 1); bitFlag++)
            {
                var result = SolveFor(bitFlag);
                min = Math.Min(min, result);
            }

            yield return min;
        }

        private int SolveFor(int bitFlag)
        {
            var rowGroups = new List<List<int>>();
            var group = new List<int>();
            rowGroups.Add(group);
            group.Add(0);

            for (int i = 1; i < h; i++)
            {
                if ((bitFlag & 0x01 << (i - 1)) != 0)
                {
                    group = new List<int>();
                    rowGroups.Add(group);
                }

                group.Add(i);
            }

            var splitCount = rowGroups.Count - 1;
            var whiteCounts = new int[rowGroups.Count];

            for (int i = 0; i < w; i++)
            {
                var currentWhiteCounts = rowGroups.Select(g => g.Count(r => isWhite[r][i])).ToArray();

                if (currentWhiteCounts.Any(n => n > k))
                {
                    // この割り方だとNGであることを返す
                    return int.MaxValue;
                }

                for (int j = 0; j < whiteCounts.Length; j++)
                {
                    whiteCounts[j] += currentWhiteCounts[j];
                }

                if (whiteCounts.Any(n => n > k))
                {
                    // 超えてたら手前で割ってリセット
                    whiteCounts = currentWhiteCounts;
                    splitCount++;
                }
            }

            return splitCount;
        }
    }
}
