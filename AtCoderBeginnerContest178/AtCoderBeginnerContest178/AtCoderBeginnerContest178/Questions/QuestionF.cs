using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest178.Algorithms;
using AtCoderBeginnerContest178.Collections;
using AtCoderBeginnerContest178.Extensions;
using AtCoderBeginnerContest178.Numerics;
using AtCoderBeginnerContest178.Questions;

namespace AtCoderBeginnerContest178.Questions
{
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var b = inputStream.ReadIntArray();

            var bucketA = new int[n + 1];
            var bucketB = new int[n + 1];

            for (int i = 0; i < a.Length; i++)
            {
                bucketA[a[i]]++;
                bucketB[b[i]]++;
            }

            for (int i = 0; i + 1 < bucketA.Length; i++)
            {
                bucketA[i + 1] += bucketA[i];
                bucketB[i + 1] += bucketB[i];
            }

            for (int i = 1; i <= n; i++)
            {
                if (bucketA[i] - bucketA[i - 1] + bucketB[i] - bucketB[i - 1] > n) 
                {
                    yield return "No";
                    yield break;
                }
            }

            var shift = new bool[n];
            shift.AsSpan().Fill(true);

            for (int i = 1; i <= n; i++)
            {
                var leftA = bucketA[i - 1];
                var rightA = bucketA[i];
                var leftB = bucketB[i - 1];
                var rightB = bucketB[i];

                if (rightA - leftA > 0 && rightB - leftB > 0)
                {
                    var toLeft = leftA - rightB + 1;
                    var toRight = rightA - leftB - 1;

                    while (toLeft < 0)
                    {
                        toLeft += n;
                    }

                    while (toLeft > toRight)
                    {
                        toRight += n;
                    }

                    for (int j = toLeft; j <= toRight; j++)
                    {
                        shift[j % n] = false;
                    }
                }
            }

            for (int i = 0; i < shift.Length; i++)
            {
                if (shift[i])
                {
                    var c = new int[n];
                    for (int j = 0; j < b.Length; j++)
                    {
                        c[(j + i) % n] = b[j];
                    }

                    yield return "Yes";
                    yield return c.Join(' ');
                    yield break;
                }
            }

            yield return "No";
        }
    }
}
