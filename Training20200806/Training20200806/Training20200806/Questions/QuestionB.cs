using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200806.Algorithms;
using Training20200806.Collections;
using Training20200806.Extensions;
using Training20200806.Numerics;
using Training20200806.Questions;

namespace Training20200806.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/code-festival-2015-quala/tasks/codefestival_2015_qualA_d
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (cars, mechanics) = inputStream.ReadValue<long, int>();
            var initialPositions = new int[mechanics];

            for (int i = 0; i < initialPositions.Length; i++)
            {
                initialPositions[i] = inputStream.ReadInt();
            }

            bool CanCheckAll(long minutes)
            {
                long seen = 0;
                foreach (var x in initialPositions)
                {
                    var distance = x - (seen + 1);
                    if (distance > minutes)
                    {
                        return false;
                    }
                    else if (distance > 0)
                    {
                        seen = Math.Max(x + minutes - distance * 2, x + (minutes - distance) / 2);
                    }
                    else
                    {
                        seen = x + minutes;
                    }
                }

                return seen >= cars;
            }

            yield return SearchExtensions.BoundaryBinarySearch(CanCheckAll, cars * 2, -1);
        }
    }
}
