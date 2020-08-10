using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu057.Algorithms;
using Kujikatsu057.Collections;
using Kujikatsu057.Extensions;
using Kujikatsu057.Numerics;
using Kujikatsu057.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Kujikatsu057.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc029/tasks/agc029_d
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (height, width, obstacleCount) = inputStream.ReadValue<int, int, int>();

            var obstacles = new List<Obstacle>(obstacleCount + height);
            for (int i = 0; i < obstacleCount; i++)
            {
                var (x, y) = inputStream.ReadValue<int, int>();
                obstacles.Add(new Obstacle(x, y));
            }

            for (int y = 1; y <= width; y++)
            {
                obstacles.Add(new Obstacle(height + 1, y));
            }

            obstacles.Sort();
            var queue = new Queue<Obstacle>(obstacles);
            int maxY = 1;

            while (queue.Peek().X == 1)
            {
                queue.Dequeue();
            }

            for (int x = 2; x <= height + 1; x++)
            {
                var canUp = true;
                while (queue.Peek().X == x)
                {
                    var obstacle = queue.Dequeue();
                    if (obstacle.Y <= maxY)
                    {
                        yield return x - 1;
                        yield break;
                    }
                    else if (obstacle.Y == maxY + 1)
                    {
                        canUp = false;
                    }
                }
                if (canUp)
                {
                    maxY++;
                }
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Obstacle : IComparable<Obstacle>
        {
            public int X { get; }
            public int Y { get; }

            public Obstacle(int x, int y)
            {
                X = x;
                Y = y;
            }

            public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
            public override string ToString() => $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";

            public int CompareTo([AllowNull] Obstacle other)
            {
                var comp = X - other.X;
                if (comp != 0)
                {
                    return comp;
                }
                else
                {
                    return Y - other.Y;
                }
            }
        }
    }
}
