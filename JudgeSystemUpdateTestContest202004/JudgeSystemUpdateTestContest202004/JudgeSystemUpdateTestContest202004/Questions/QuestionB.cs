using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using JudgeSystemUpdateTestContest202004.Extensions;

namespace JudgeSystemUpdateTestContest202004.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<string> Solve(TextReader inputStream)
        {
            var redBalls = new List<int>();
            var blueBalls = new List<int>();

            var n = inputStream.ReadInt();

            for (int i = 0; i < n; i++)
            {
                var xc = inputStream.ReadStringArray();
                var number = int.Parse(xc[0]);

                if (xc[1] == "R")
                {
                    redBalls.Add(number);
                }
                else
                {
                    blueBalls.Add(number);
                }
            }

            redBalls.Sort();
            blueBalls.Sort();
            var balls = redBalls.Concat(blueBalls);
            
            foreach (var ball in balls)
            {
                yield return ball.ToString();
            }
        }
    }
}
