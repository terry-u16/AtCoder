using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200726.Algorithms;
using Training20200726.Collections;
using Training20200726.Extensions;
using Training20200726.Numerics;
using Training20200726.Questions;
using System.Net.WebSockets;

namespace Training20200726.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/m-solutions2020/tasks/m_solutions2020_f
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var planes = new Plane[n];
            for (int i = 0; i < planes.Length; i++)
            {
                var (x, y, u) = inputStream.ReadValue<int, int, char>();
                planes[i] = new Plane(x * 10, y * 10, ToDirection(u));
            }

            var collisionTime = int.MaxValue;

            // 正面
            collisionTime = Math.Min(collisionTime, CheckOppositeCollisions(planes));
            planes = planes.Select(p => p.RotateClockwise()).ToArray();
            collisionTime = Math.Min(collisionTime, CheckOppositeCollisions(planes));

            // 側面
            collisionTime = Math.Min(collisionTime, CheckSideCollision(planes));
            for (int i = 0; i < 3; i++)
            {
                planes = planes.Select(p => p.RotateClockwise()).ToArray();
                collisionTime = Math.Min(collisionTime, CheckSideCollision(planes));
            }

            if (collisionTime < int.MaxValue)
            {
                yield return collisionTime;
            }
            else
            {
                yield return "SAFE";
            }
        }

        int CheckOppositeCollisions(Plane[] planes)
        {
            var collisionTime = int.MaxValue;

            var horizontalGroups = planes.GroupBy(p => p.Y).ToArray();

            foreach (var group in horizontalGroups)
            {
                var easts = group.Where(p => p.Direction == Direction.East).ToArray();
                var wests = group.Where(p => p.Direction == Direction.West).OrderBy(p => p.X).ToArray();

                foreach (var eastPlane in easts)
                {
                    var opponentIndex = SearchExtensions.BoundaryBinarySearch(i => wests[i].X > eastPlane.X, wests.Length, -1);
                    if (opponentIndex < wests.Length)
                    {
                        collisionTime = Math.Min(collisionTime, (wests[opponentIndex].X - eastPlane.X) / 2);
                    }
                }
            }

            return collisionTime;
        }

        int CheckSideCollision(Plane[] planes)
        {
            int collisionTime = int.MaxValue;

            var groups = planes.Where(p => p.Direction == Direction.East || p.Direction == Direction.North)
                               .GroupBy(p => p.X + p.Y)
                               .ToArray();

            foreach (var group in groups)
            {
                var easts = group.Where(p => p.Direction == Direction.East).Select(p => -p.X + p.Y).ToArray();
                var norths = group.Where(p => p.Direction == Direction.North).Select(p => -p.X + p.Y).OrderBy(u => u).ToArray();

                foreach (var east in easts)
                {
                    var opponentIndex = SearchExtensions.BoundaryBinarySearch(i => norths[i] < east, -1, norths.Length);
                    if (opponentIndex >= 0)
                    {
                        collisionTime = Math.Min(collisionTime, (east - norths[opponentIndex]) / 2);
                    }
                }
            }

            return collisionTime;
        }

        Direction ToDirection(char direction)
        {
            return direction switch
            {
                'U' => Direction.North,
                'R' => Direction.East,
                'D' => Direction.South,
                'L' => Direction.West,
                _ => Direction.North
            };
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Plane
        {
            public int X { get; }
            public int Y { get; }
            public Direction Direction { get; }

            public Plane(int x, int y, Direction direction)
            {
                X = x;
                Y = y;
                Direction = direction;
            }

            public Plane RotateClockwise() => new Plane(Y, -X, RotateClockwise(Direction));
            private Direction RotateClockwise(Direction direction) => (Direction)(((int)direction + 1) % 4);

            public override string ToString() => $"{nameof(X)}: {X}, {nameof(Y)}: {Y}, {nameof(Direction)}: {Direction}";
        }

        enum Direction
        {
            North = 0,
            East = 1,
            South = 2,
            West = 3
        }
    }
}
