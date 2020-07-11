using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu026.Algorithms;
using Kujikatsu026.Collections;
using Kujikatsu026.Extensions;
using Kujikatsu026.Numerics;
using Kujikatsu026.Questions;

namespace Kujikatsu026.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            long ab = long.Parse(inputStream.ReadStringArray().Join());

            for (long i = 1; i < 100000; i++)
            {
                if (i * i == ab)
                {
                    yield return "Yes";
                    yield break;
                }
            }

            yield return "No";
        }
    }
}
