using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest175.Algorithms;
using AtCoderBeginnerContest175.Collections;
using AtCoderBeginnerContest175.Extensions;
using AtCoderBeginnerContest175.Numerics;
using AtCoderBeginnerContest175.Questions;

namespace AtCoderBeginnerContest175.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var l = inputStream.ReadIntArray();
            Array.Sort(l);

            var count = 0;
            for (int i = 0; i < l.Length; i++)
            {
                for (int j = i + 1; j < l.Length; j++)
                {
                    for (int k = j + 1; k < l.Length; k++)
                    {
                        if (l[i] != l[j] && l[j] != l[k] && l[i] + l[j] > l[k])
                        {
                            count++;
                        }
                    }
                }
            }

            yield return count;
        }
    }
}
