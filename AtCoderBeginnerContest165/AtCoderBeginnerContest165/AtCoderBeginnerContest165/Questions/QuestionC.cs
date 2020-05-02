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
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (length, maxNumber, queryCount) = inputStream.ReadValue<int, int, int>();

            var queries = new (int a, int b, int c, int point)[queryCount];

            var numbers = new int[10];

            for (int i = 0; i < queryCount; i++)
            {
                queries[i] = inputStream.ReadValue<int, int, int, int>();
            }

            queries = queries.OrderByDescending(q => q.point).ToArray();

            var max = 0;

            for (numbers[0] = 1; numbers[0] <= maxNumber; numbers[0]++)
            {
                for (numbers[1] = numbers[0]; numbers[1] <= maxNumber; numbers[1]++)
                {
                    for (numbers[2] = numbers[1]; numbers[2] <= maxNumber; numbers[2]++)
                    {
                        for (numbers[3] = numbers[2]; numbers[3] <= maxNumber; numbers[3]++)
                        {
                            for (numbers[4] = numbers[3]; numbers[4] <= maxNumber; numbers[4]++)
                            {
                                for (numbers[5] = numbers[4]; numbers[5] <= maxNumber; numbers[5]++)
                                {
                                    for (numbers[6] = numbers[5]; numbers[6] <= maxNumber; numbers[6]++)
                                    {
                                        for (numbers[7] = numbers[6]; numbers[7] <= maxNumber; numbers[7]++)
                                        {
                                            for (numbers[8] = numbers[7]; numbers[8] <= maxNumber; numbers[8]++)
                                            {
                                                for (numbers[9] = numbers[8]; numbers[9] <= maxNumber; numbers[9]++)
                                                {
                                                    var point = 0;
                                                    foreach (var (a, b, c, d) in queries)
                                                    {
                                                        if (numbers[b - 1] - numbers[a - 1] == c)
                                                        {
                                                            point += d;
                                                        }
                                                    }
                                                    max = Math.Max(max, point);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            yield return max;
        }
    }
}
