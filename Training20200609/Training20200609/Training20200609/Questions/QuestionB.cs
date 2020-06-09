using Training20200609.Questions;
using Training20200609.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200609.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc062/tasks/arc062_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var hands = inputStream.ReadLine();

            int paperCount = 0;
            int rockCount = 0;
            int score = 0;

            foreach (var hand in hands)
            {
                if (paperCount < rockCount)
                {
                    // パーを出す
                    paperCount++;
                    if (hand == 'g')
                    {
                        score++;
                    }
                }
                else
                {
                    // グーを出す
                    rockCount++;
                    if (hand == 'p')
                    {
                        score--;
                    }
                }
            }

            yield return score;
        }
    }
}
