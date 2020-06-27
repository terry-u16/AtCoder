using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest172.Algorithms;
using AtCoderBeginnerContest172.Collections;
using AtCoderBeginnerContest172.Extensions;
using AtCoderBeginnerContest172.Numerics;
using AtCoderBeginnerContest172.Questions;

namespace AtCoderBeginnerContest172.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, m, maxMinutes) = inputStream.ReadValue<int, int, int>();
            var a = inputStream.ReadLongArray();
            var b = inputStream.ReadLongArray();

            long sum = 0;
            var maxBooks = 0;
            var indexA = 0;
            var indexB = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (sum + a[i] <= maxMinutes)
                {
                    sum += a[i];
                    indexA++;
                }
                else
                {
                    break;
                }
            }

            for (int i = 0; i < b.Length; i++)
            {
                if (sum + b[i] <= maxMinutes)
                {
                    sum += b[i];
                    indexB++;
                }
                else
                {
                    break;
                }
            }

            maxBooks = indexA + indexB;

            while (indexA > 0)
            {
                sum -= a[--indexA];
                for (int i = indexB; i < b.Length; i++)
                {
                    if (sum + b[i] <= maxMinutes)
                    {
                        sum += b[i];
                        indexB++;
                    }
                    else
                    {
                        break;
                    }
                }
                maxBooks = Math.Max(maxBooks, indexA + indexB);
            }

            yield return maxBooks;
        }
    }
}
