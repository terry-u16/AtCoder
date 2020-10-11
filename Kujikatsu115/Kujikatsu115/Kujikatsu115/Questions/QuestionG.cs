using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu115.Algorithms;
using Kujikatsu115.Collections;
using Kujikatsu115.Numerics;
using Kujikatsu115.Questions;

namespace Kujikatsu115.Questions
{
    public class QuestionG : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            const int MaxDigit = 28;
            var n = io.ReadInt();
            var a = io.ReadIntArray(n);
            var b = io.ReadIntArray(n);
            var bWork = new int[n];

            var result = 0;

            for (int digit = 0; digit <= MaxDigit; digit++)
            {
                var highest = 1 << digit;
                var mask = (1 << (digit + 1)) - 1;
                for (int i = 0; i < b.Length; i++)
                {
                    bWork[i] = b[i] & mask;
                }
                bWork.Sort();

                long count = 0;

                foreach (var ai in a)
                {
                    var currentA = ai & mask;
                    var zero = SearchExtensions.GetGreaterEqualIndex(bWork, highest - currentA);
                    var one = SearchExtensions.GetGreaterEqualIndex(bWork, highest * 2 - currentA);
                    var two = SearchExtensions.GetGreaterEqualIndex(bWork, highest * 3 - currentA);
                    count += bWork.Length - two + one - zero;
                }

                result |= (int)(count & 1) << digit;
            }

            io.WriteLine(result);
        }
    }
}
