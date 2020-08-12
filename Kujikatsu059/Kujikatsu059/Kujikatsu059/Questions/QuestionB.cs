using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu059.Algorithms;
using Kujikatsu059.Collections;
using Kujikatsu059.Extensions;
using Kujikatsu059.Numerics;
using Kujikatsu059.Questions;

namespace Kujikatsu059.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var operations = inputStream.ReadLine();

            var x = 0;
            var max = x;

            foreach (var op in operations)
            {
                if (op == 'I')
                {
                    x++;
                }
                else
                {
                    x--;
                }
                max = Math.Max(max, x);
            }

            yield return max;
        }
    }
}
