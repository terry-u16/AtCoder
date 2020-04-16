using Yorukatsu017.Questions;
using Yorukatsu017.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu017.Questions
{
    /// <summary>
    /// ABC075 B
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        bool[][] hasMine;
        int?[][] numbers;
        int h;
        int w;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var hw = inputStream.ReadIntArray();
            h = hw[0];
            w = hw[1];

            hasMine = new bool[h][];
            numbers = new int?[h][];

            for (int i = 0; i < h; i++)
            {
                hasMine[i] = inputStream.ReadLine().Select(c => c == '#').ToArray();
                numbers[i] = hasMine[i].Select(b => b ? null : new int?(0)).ToArray();
            }

            Search();

            foreach (var numberRow in numbers)
            {
                yield return string.Concat(numberRow.Select(i => i == null ? "#" : i.Value.ToString()));
            }
        }

        void Search()
        {
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (hasMine[i][j])
                    {
                        for (int k = Math.Max(i - 1, 0); k <= Math.Min(i + 1, h - 1); k++)
                        {
                            for (int l = Math.Max(j - 1, 0); l <= Math.Min(j + 1, w - 1); l++)
                            {
                                if (!hasMine[k][l])
                                {
                                    numbers[k][l] += 1;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
