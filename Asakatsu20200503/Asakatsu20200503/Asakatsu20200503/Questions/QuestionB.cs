using Asakatsu20200503.Questions;
using Asakatsu20200503.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Asakatsu20200503.Questions
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
                var minDistance = int.MaxValue;
                var minIndex = -1;
                for (int i = 0; i < checkPoints.Length; i++)
                {
                    var distance = student.GetManhattanDistance(checkPoints[i]);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        minIndex = i + 1;
                    }
                }
                yield return minIndex;
            }
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

        public int GetManhattanDistance(Position other) => Math.Abs(X - other.X) + Math.Abs(Y - other.Y);
    }
}
