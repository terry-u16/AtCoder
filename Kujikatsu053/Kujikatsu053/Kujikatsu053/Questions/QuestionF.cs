using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu053.Algorithms;
using Kujikatsu053.Collections;
using Kujikatsu053.Extensions;
using Kujikatsu053.Numerics;
using Kujikatsu053.Questions;

namespace Kujikatsu053.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc127/tasks/abc127_e
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            Modular.InitializeCombinationTable();
            var (height, width, k) = inputStream.ReadValue<int, int, int>();
            yield return Sum(width, height, k) + Sum(height, width, k);
        }

        Modular Sum(int width, int height, int k)
        {
            var result = Modular.Zero;
            var squares = width * height;
           
            for (int distance = 1; distance < width; distance++)
            {
                result += new Modular(distance) * new Modular(height) * new Modular(height) * Modular.Combination(squares - 2, k - 2) * new Modular(width - distance);
            }

            return result;
        }
    }
}
