using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest173.Algorithms;
using AtCoderBeginnerContest173.Collections;
using AtCoderBeginnerContest173.Extensions;
using AtCoderBeginnerContest173.Numerics;
using AtCoderBeginnerContest173.Questions;

namespace AtCoderBeginnerContest173.Questions
{
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            long n = inputStream.ReadInt();
            long nodes = 0;
            long edges = 0;

            for (long length = 1; length <= n; length++)
            {
                nodes += length * (n - length + 1);
            }

            for (int i = 0; i < n - 1; i++)
            {
                var (u, v) = inputStream.ReadValue<long, long>();
                if (u > v)
                {
                    Swap(ref u, ref v);
                }
                edges += u * (n - v + 1);
            }

            yield return nodes - edges;
        }

        void Swap<T>(ref T a, ref T b)
        {
            var temp = a;
            a = b;
            b = temp;
        }
    }
}
