using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Training20200621.Algorithms;
using Training20200621.Collections;
using Training20200621.Extensions;
using Training20200621.Numerics;
using Training20200621.Questions;

namespace Training20200621.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/diverta2019-2/tasks/diverta2019_2_c
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();

            Array.Sort(a);
            var operations = new Queue<(int, int)>(a.Length);
            for (int i = 1; i < a.Length - 1; i++)
            {
                if (a[i] >= 0)
                {
                    operations.Enqueue((a[0], a[i]));
                    a[0] -= a[i];
                }
                else
                {
                    operations.Enqueue((a[a.Length - 1], a[i]));
                    a[a.Length - 1] -= a[i];
                }
            }

            operations.Enqueue((a[a.Length - 1], a[0]));
            a[a.Length - 1] -= a[0];

            yield return a[a.Length - 1];
            foreach (var (x, y) in operations)
            {
                yield return $"{x} {y}";
            }
        }
    }
}
