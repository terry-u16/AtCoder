using EducationalDPContest.Questions;
using EducationalDPContest.Extensions;
using EducationalDPContest.Algorithms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EducationalDPContest.Questions
{
    public class QuestionI : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            int n = inputStream.ReadInt();
            var p = inputStream.ReadDoubleArray();

            var probabilities = new double[n + 1, n + 1]; // i枚目まで投げたときにj枚表になる確率

            probabilities[0, 0] = 1;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    var front = j != 0 ? probabilities[i - 1, j - 1] * p[i - 1] : 0;
                    var back = probabilities[i - 1, j] * (1 - p[i - 1]);
                    probabilities[i, j] = front + back;
                }
            }

            double sum = 0;
            for (int i = (n + 1) / 2; i <= n; i++)
            {
                sum += probabilities[n, i];
            }

            yield return sum;
        }
    }
}
