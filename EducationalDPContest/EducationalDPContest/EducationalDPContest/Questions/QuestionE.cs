using EducationalDPContest.Questions;
using EducationalDPContest.Extensions;
using EducationalDPContest.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EducationalDPContest.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nw = inputStream.ReadIntArray();
            var n = nw[0];
            var capacity = nw[1];
            const int maxTotalValue = 100 * 1000;

            var minWeights = Create2DArray(n + 1, maxTotalValue + 1, long.MaxValue >> 4);

            minWeights[0][0] = 0;

            for (int i = 1; i <= n; i++)
            {
                var wv = inputStream.ReadIntArray();
                var w = wv[0];
                var v = wv[1];

                for (int valueSum = 0; valueSum < minWeights[i].Length; valueSum++)
                {
                    if (valueSum - v >= 0)
                    {
                        UpdateWhenSmall(ref minWeights[i][valueSum], minWeights[i - 1][valueSum - v] + w);
                    }

                    UpdateWhenSmall(ref minWeights[i][valueSum], minWeights[i - 1][valueSum]);
                }
            }

            var maxIndex = 0;
            for (int i = 0; i < minWeights[n].Length; i++)
            {
                if (minWeights[n][i] <= capacity)
                {
                    maxIndex = i;
                }
            }
            yield return maxIndex;
        }

        T[][] Create2DArray<T>(int dim1, int dim2, T value)
        {
            var array = new T[dim1][];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Enumerable.Repeat(value, dim2).ToArray();
            }
            return array;
        }

    }
}
