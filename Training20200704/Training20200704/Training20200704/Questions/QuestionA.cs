using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200704.Algorithms;
using Training20200704.Collections;
using Training20200704.Extensions;
using Training20200704.Numerics;
using Training20200704.Questions;

namespace Training20200704.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/indeednow-quala/tasks/indeednow_2015_quala_3
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var people = new int[1000002];

            for (int i = 0; i < n; i++)
            {
                var s = inputStream.ReadInt();
                if (s > 0)
                {
                    people[s]++;
                }
            }

            for (int i = people.Length - 1; i - 1 >= 0; i--)
            {
                people[i - 1] += people[i];
            }

            var queries = inputStream.ReadInt();

            for (int q = 0; q < queries; q++)
            {
                var k = inputStream.ReadInt();
                yield return SearchExtensions.BoundaryBinarySearch(p => people[p] <= k, people.Length, -1);
            }
        }
    }
}
