using Yorukatsu016.Questions;
using Yorukatsu016.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu016.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        /// <summary>
        /// ABC161 D
        /// </summary>
        /// <param name="inputStream"></param>
        /// <returns></returns>
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var k = inputStream.ReadInt();

            var lunluns = new Queue<long>();

            for (int i = 1; i < 10; i++)
            {
                lunluns.Enqueue(i);
            }

            long lunlun = 0;
            for (int i = 1; i <= k; i++)
            {
                lunlun = lunluns.Dequeue();
                var lastDigit = lunlun % 10;

                if (lastDigit != 0)
                {
                    lunluns.Enqueue(lunlun * 10 + lastDigit - 1);
                }
                lunluns.Enqueue(lunlun * 10 + lastDigit);
                if (lastDigit != 9)
                {
                    lunluns.Enqueue(lunlun * 10 + lastDigit + 1);
                }
            }

            yield return lunlun;
        }
    }
}
