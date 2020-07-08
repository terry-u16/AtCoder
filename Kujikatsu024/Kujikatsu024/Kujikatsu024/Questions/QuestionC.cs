using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu024.Algorithms;
using Kujikatsu024.Collections;
using Kujikatsu024.Extensions;
using Kujikatsu024.Numerics;
using Kujikatsu024.Questions;

namespace Kujikatsu024.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            const int Transportations = 5;
            var n = inputStream.ReadLong();
            var capacities = new long[Transportations];

            for (int i = 0; i < capacities.Length; i++)
            {
                capacities[i] = inputStream.ReadLong();
            }

            var neck = capacities.Max(c => (n + c - 1) / c);
            yield return neck + Transportations - 1;
        }
    }
}
