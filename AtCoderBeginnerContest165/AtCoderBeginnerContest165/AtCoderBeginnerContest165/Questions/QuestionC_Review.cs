using AtCoderBeginnerContest165.Algorithms;
using AtCoderBeginnerContest165.Collections;
using AtCoderBeginnerContest165.Questions;
using AtCoderBeginnerContest165.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest165.Questions
{
    public class QuestionC_Review : AtCoderQuestionBase
    {
        int length;
        int maxNumber;
        int queryCount;
        
        (int a, int b, int c, int d)[] queries;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            (length, maxNumber, queryCount) = inputStream.ReadValue<int, int, int>();

            var numbers = new int[10];
            queries = new (int a, int b, int c, int d)[queryCount];

            for (int i = 0; i < queryCount; i++)
            {
                queries[i] = inputStream.ReadValue<int, int, int, int>();
            }
            var array = new int[length + 1];
            array[0] = 1;
            yield return GetMax(array, 1, 0);
        }

        private int GetMax(int[] array, int index, int max)
        {
            if (index < array.Length)
            {
                for (int ai = array[index - 1]; ai <= maxNumber; ai++)
                {
                    array[index] = ai;
                    max = Math.Max(max, GetMax(array, index + 1, max));
                }
            }
            else
            {
                var point = 0;
                foreach (var (a, b, c, d) in queries)
                {
                    if (array[b] - array[a] == c)
                    {
                        point += d;
                    }
                }
                max = Math.Max(max, point);
            }
            return max;
        }
    }
}
