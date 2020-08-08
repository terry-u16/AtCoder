using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200808.Algorithms;
using Training20200808.Collections;
using Training20200808.Extensions;
using Training20200808.Numerics;
using Training20200808.Questions;

namespace Training20200808.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc150/tasks/abc150_e
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var costs = inputStream.ReadIntArray();
            Array.Sort(costs);
            Array.Reverse(costs);

            var result = Modular.Zero;

            for (int i = 0; i < costs.Length; i++)
            {
                var factor = (i == 0 ? 1 : (Modular.Pow(2, i) + (Modular.Pow(2, i - 1) * i))) * Modular.Pow(2, costs.Length - i - 1);
                result += factor * costs[i];
            }

            yield return result * Modular.Pow(2, costs.Length);
        }
    }
}
