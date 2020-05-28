using Yorukatsu051.Questions;
using Yorukatsu051.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu051.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();

            var plans = new Plan[n + 1];
            for (int i = 0; i < n; i++)
            {
                var txy = inputStream.ReadIntArray();
                plans[i + 1] = new Plan(txy[0], txy[1], txy[2]);
            }

            for (int i = 0; i < n; i++)
            {
                var requiredTime = plans[i].Coordinate.GetDistanceTo(plans[i + 1].Coordinate);
                var remainTime = plans[i + 1].Time - plans[i].Time - requiredTime;
                if (remainTime < 0 || remainTime % 2 != 0)
                {
                    yield return "No";
                    yield break;
                }
            }

            yield return "Yes";
        }

        struct Plan
        {
            public int Time { get; }
            public Coordinate Coordinate { get; }

            public Plan(int time, int x, int y)
            {
                Time = time;
                Coordinate = new Coordinate(x, y);
            }
        }

        struct Coordinate
        {
            public int X { get; }
            public int Y { get; }

            public Coordinate(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int GetDistanceTo(Coordinate coordinate) => Math.Abs(X - coordinate.X) + Math.Abs(Y - coordinate.Y);
        }
    }
}
