using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu055.Algorithms;
using Kujikatsu055.Collections;
using Kujikatsu055.Extensions;
using Kujikatsu055.Numerics;
using Kujikatsu055.Questions;

namespace Kujikatsu055.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (_, length) = inputStream.ReadValue<int, int>();
            var a = inputStream.ReadLongArray();
            var adjacents = new long[a.Length - 1];
            for (int i = 0; i < adjacents.Length; i++)
            {
                adjacents[i] = a[i] + a[i + 1];
            }

            if (adjacents.Any(adj => adj >= length))
            {
                yield return "Possible";

                var last = -1;
                for (int i = 0; i < adjacents.Length; i++)
                {
                    if (adjacents[i] >= length)
                    {
                        last = i;
                        break;
                    }
                }

                last += 1; // 1-index
                for (int i = 1; i <= last - 1; i++)
                {
                    yield return i;
                }
                for (int i = a.Length - 1; i >= last + 1; i--)
                {
                    yield return i;
                }
                yield return last;
            }
            else
            {
                yield return "Impossible";
            }
        }
    }
}
