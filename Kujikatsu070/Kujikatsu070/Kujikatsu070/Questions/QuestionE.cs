using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu070.Algorithms;
using Kujikatsu070.Collections;
using Kujikatsu070.Extensions;
using Kujikatsu070.Numerics;
using Kujikatsu070.Questions;

namespace Kujikatsu070.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (_, k) = inputStream.ReadValue<int, int>();
            var values = inputStream.ReadIntArray();

            var max = 0;

            for (int leftTake = 0; leftTake <= Math.Min(k, values.Length); leftTake++)
            {
                for (int rightTake = 0; leftTake + rightTake <= Math.Min(k, values.Length); rightTake++)
                {
                    var taken = new List<int>();

                    for (int i = 0; i < leftTake; i++)
                    {
                        taken.Add(values[i]);
                    }

                    for (int i = 0; i < rightTake; i++)
                    {
                        taken.Add(values[^(i + 1)]);
                    }

                    var operations = k - leftTake - rightTake;
                    taken.Sort();
                    var queue = new Queue<int>(taken);

                    while (operations-- > 0 && queue.Count > 0 && queue.Peek() < 0)
                    {
                        queue.Dequeue();
                    }

                    max = Math.Max(max, queue.Sum());
                }
            }

            yield return max;
        }
    }
}
