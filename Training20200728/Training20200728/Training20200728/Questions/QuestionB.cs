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
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var k = inputStream.ReadLine().Select(c => c - '0').ToArray();
            var d = inputStream.ReadInt();
            var counts = new Modular[k.Length + 1, 2, d];
            const int Equal = 0;
            const int Less = 1;

            counts[0, Equal, 0] = 1;

            for (int digit = 0; digit < k.Length; digit++)
            {
                for (int mod = 0; mod < d; mod++)
                {
                    // Equal
                    counts[digit + 1, Equal, (mod + k[digit]) % d] += counts[digit, Equal, mod];
                    for (int added = 0; added < k[digit]; added++)
                    {
                        counts[digit + 1, Less, (mod + added) % d] += counts[digit, Equal, mod];
                    }

                    // Less
                    for (int added = 0; added <= 9; added++)
                    {
                        counts[digit + 1, Less, (mod + added) % d] += counts[digit, Less, mod];
                    }
                }
            }

            yield return counts[k.Length, Equal, 0] + counts[k.Length, Less, 0] - 1;
        }
    }
}
