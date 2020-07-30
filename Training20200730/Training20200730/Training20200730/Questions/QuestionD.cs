using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200730.Algorithms;
using Training20200730.Collections;
using Training20200730.Extensions;
using Training20200730.Numerics;
using Training20200730.Questions;

namespace Training20200730.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc043/tasks/arc043_b
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var difficulties = new int[n];
            for (int i = 0; i < difficulties.Length; i++)
            {
                difficulties[i] = inputStream.ReadInt();
            }

            Array.Sort(difficulties);

            var count2 = new Modular[n];
            var count3 = new Modular[n];

            for (int i = 0; i < count2.Length; i++)
            {
                count2[i] = SearchExtensions.GetLessEqualIndex(difficulties, difficulties[i] / 2) + 1;
            }

            for (int i = 0; i < count3.Length; i++)
            {
                count3[i] = difficulties.Length - SearchExtensions.GetGreaterEqualIndex(difficulties, difficulties[i] * 2);
            }

            var result = Modular.Zero;
            var prefixSum = new Modular[n + 1];
            for (int i = 0; i < count2.Length; i++)
            {
                prefixSum[i + 1] = prefixSum[i] + count2[i];
            }
            for (int i = 0; i < count3.Length; i++)
            {
                var index = SearchExtensions.GetLessEqualIndex(difficulties, difficulties[i] / 2) + 1;
                result += prefixSum[index] * count3[i];
            }

            yield return result;
        }
    }
}
