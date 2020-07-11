using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aising2020.Algorithms;
using Aising2020.Collections;
using Aising2020.Extensions;
using Aising2020.Numerics;
using Aising2020.Questions;

namespace Aising2020.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var counts = new long[n + 1];

            for (int x = 1; x <= 100; x++)
            {
                for (int y = 1; y <= 100; y++)
                {
                    for (int z = 1; z <= 100; z++)
                    {
                        var result = x * x + y * y + z * z + x * y + y * z + z * x;
                        if (result < counts.Length)
                        {
                            counts[result]++;
                        }
                    }
                }
            }

            for (int i = 1; i < counts.Length; i++)
            {
                yield return counts[i];
            }
        }
    }
}
