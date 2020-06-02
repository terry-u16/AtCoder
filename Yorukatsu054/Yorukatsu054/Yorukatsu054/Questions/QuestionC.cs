using Yorukatsu054.Questions;
using Yorukatsu054.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu054.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc149/tasks/abc149_d
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadIntArray();
            var jankenCount = nk[0];
            var restriction = nk[1];
            var rspPoints = inputStream.ReadIntArray();
            var hostileHands = inputStream.ReadLine().Select(ToInt).ToArray();
            var myHands = Enumerable.Repeat(-1, jankenCount).ToArray();

            var pointSum = 0;
            for (int i = 0; i < hostileHands.Length; i++)
            {
                var winnable = (hostileHands[i] + 2) % 3;

                if (i - restriction < 0 || myHands[i - restriction] != winnable)
                {
                    myHands[i] = winnable;
                    pointSum += rspPoints[winnable];
                }
            }

            yield return pointSum;
        }

        int ToInt(char c)
        {
            switch (c)
            {
                case 'r':
                    return 0;
                case 's':
                    return 1;
                case 'p':
                    return 2;
                default:
                    return -1;
            }
        }
    }
}
