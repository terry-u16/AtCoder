using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200728.Algorithms;
using Training20200728.Collections;
using Training20200728.Extensions;
using Training20200728.Numerics;
using Training20200728.Questions;

namespace Training20200728.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/dp/tasks/dp_r
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k) = inputStream.ReadValue<int, long>();
            var initialVector = new ModVector(Enumerable.Repeat(Modular.One, n).ToArray());
            var matrix = new ModMatrix(n);

            for (int i = 0; i < n; i++)
            {
                var a = inputStream.ReadIntArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = a[j];
                }
            }

            var resultVector = matrix.Pow(k) * initialVector;

            var result = Modular.Zero;
            for (int i = 0; i < resultVector.Length; i++)
            {
                result += resultVector[i];
            }

            yield return result;
        }
    }
}
