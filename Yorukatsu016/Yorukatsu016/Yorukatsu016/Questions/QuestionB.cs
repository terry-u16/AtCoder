using Yorukatsu016.Questions;
using Yorukatsu016.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu016.Questions
{
    /// <summary>
    /// ABC057 B
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var n = nm[0];
            var m = nm[1];

            var students = new Position[n];
            var checkPoints = new Position[m];

            for (int i = 0; i < n; i++)
            {
                var ab = inputStream.ReadIntArray();
                students[i] = new Position(ab[0], ab[1]);
            }

            for (int i = 0; i < m; i++)
            {
                var cd = inputStream.ReadIntArray();
                checkPoints[i] = new Position(cd[0], cd[1]);
            }

            foreach (var student in students)
            {
                var min = int.MaxValue;
                var minIndex = -1;
                for (int i = 0; i < checkPoints.Length; i++)
                {
                    var distance = student.GetDistanceTo(checkPoints[i]);
                    if (min > distance)
                    {
                        minIndex = i + 1;
                        min = distance;
                    }
                }

                yield return minIndex;
            }
        }

        struct Position
        {
            public int X { get; }
            public int Y { get; }

            public Position(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int GetDistanceTo(Position other) => Math.Abs(X - other.X) + Math.Abs(Y - other.Y);
        }
    }
}
