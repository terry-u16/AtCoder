using AtCoderBeginnerContest134.Questions;
using AtCoderBeginnerContest134.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest134.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray(); // 0-indexed

            var balls = new bool[n];    // 0-indexed

            for (int i = a.Length - 1; i >= 0; i--)
            {
                var number = i + 1;
                var ballSum = 0;
                for (int multiple = number * 2; multiple < n + 1; multiple += number)
                {
                    if (balls[multiple - 1])
                    {
                        ballSum++;
                    }
                }
                balls[i] = (ballSum + a[i]) % 2 == 1;
            }
            
            var count = balls.Count(b => b);

            yield return count;

            if (count == 0)
            {
                yield break;
            }

            var ballIndexes = new Queue<int>();
            for (int i = 0; i < balls.Length; i++)
            {
                if (balls[i])
                {
                    ballIndexes.Enqueue(i + 1);
                }
            }

            yield return string.Join(" ", ballIndexes);
        }
    }
}
