using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AtCoderBeginnerContest161.Extensions;

namespace AtCoderBeginnerContest161.Questions
{
    public class QuestionD_Review : AtCoderQuestionBase
    {
        public override IEnumerable<string> Solve(TextReader inputStream)
        {
            var k = inputStream.ReadInt();
            var queue = new Queue<long>();

            for (long i = 1; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            long lunlun = -1L;

            for (int i = 0; i < k; i++)
            {
                lunlun = queue.Dequeue();

                for (long j = -1; j <= 1; j++)
                {
                    long d = lunlun % 10 + j;
                    if (d >= 0 && d < 10)
                    {
                        queue.Enqueue(lunlun * 10 + d);
                    }
                }
            }

            yield return lunlun.ToString();
        }
    }
}
