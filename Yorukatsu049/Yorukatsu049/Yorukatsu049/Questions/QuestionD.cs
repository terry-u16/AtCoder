using Yorukatsu049.Questions;
using Yorukatsu049.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu049.Questions
{
    /// <summary>
    /// ABC109 D
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var hw = inputStream.ReadIntArray();
            var height = hw[0];
            var width = hw[1];

            var a = new int[height][];
            for (int row = 0; row < height; row++)
            {
                a[row] = inputStream.ReadIntArray();
            }

            var outputs = new Queue<string>();

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    if (a[row][column] % 2 != 0)
                    {
                        if (column + 1 < a[row].Length)
                        {
                            a[row][column]--;
                            a[row][column + 1]++;
                            outputs.Enqueue($"{row + 1} {column + 1} {row + 1} {column + 2}");
                        }
                        else if (row + 1 < a.Length)
                        {
                            a[row][column]--;
                            a[row + 1][column]++;
                            outputs.Enqueue($"{row + 1} {column + 1} {row + 2} {column + 1}");
                        }
                    }
                }
            }

            yield return outputs.Count;
            foreach (var output in outputs)
            {
                yield return output;
            }
        }
    }
}
