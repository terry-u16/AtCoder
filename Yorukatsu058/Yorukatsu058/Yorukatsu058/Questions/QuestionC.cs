using Yorukatsu058.Questions;
using Yorukatsu058.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu058.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc149/tasks/abc149_d
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadIntArray();
            var round = nk[0];
            var restriction = nk[1];

            var rspPoint = inputStream.ReadIntArray();
            var enemyHands = inputStream.ReadLine().Select(GetHand).ToArray();
            var myHands = Enumerable.Repeat(Hand.None, round).ToArray();

            var point = 0;
            for (int r = 0; r < enemyHands.Length; r++)
            {
                var winnable = (Hand)(((int)enemyHands[r] + 2) % 3);
                if (r < restriction || myHands[r - restriction] != winnable)
                {
                    point += rspPoint[(int)winnable];
                    myHands[r] = winnable;
                }
            }

            yield return point;
        }

        enum Hand
        {
            None = -1,
            Rock = 0,
            Scissors = 1,
            Paper = 2
        }

        Hand GetHand(char c)
        {
            switch (c)
            {
                case 'r':
                    return Hand.Rock;
                case 's':
                    return Hand.Scissors;
                case 'p':
                    return Hand.Paper;
                default:
                    return Hand.None;
            }
        }
    }
}
