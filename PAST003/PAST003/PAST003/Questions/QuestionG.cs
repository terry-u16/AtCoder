using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PAST003.Algorithms;
using PAST003.Collections;
using PAST003.Extensions;
using PAST003.Numerics;
using PAST003.Questions;

namespace PAST003.Questions
{
    public class QuestionG : AtCoderQuestionBase
    {
        readonly char[,] map = new char[1000, 1000];
        readonly bool[,] seen = new bool[1000, 1000];
        const int offset = 500;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (obstaclesCount, goalX, goalY) = inputStream.ReadValue<int, int, int>();
            map.SetAll((i, j) => '.');
            map[offset, offset] = 'S';
            map[offset + goalX, offset + goalY] = 'G';

            for (int i = 0; i < obstaclesCount; i++)
            {
                var (x, y) = inputStream.ReadValue<int, int>();
                map[offset + x, offset + y] = '#';
            }

            for (int i = 0; i < 1000; i++)
            {
                map[i, 0] = '#';
                map[i, 999] = '#';
                map[0, i] = '#';
                map[999, i] = '#';
            }

            yield return Bfs(0, 0);
        }

        int Bfs(int x, int y)
        {
            var todo = new Queue<(int x, int y, int distance)>();
            todo.Enqueue((0, 0, 0));
            seen[offset, offset] = true;
            var move = new (int dx, int dy)[] { (1, 1), (-1, 1), (1, 0), (0, 1), (-1, 0), (0, -1) };

            while (todo.Count > 0)
            {
                var (currentX, currentY, currentDistance) = todo.Dequeue();

                foreach (var (dx, dy) in move)
                {
                    var nextX = currentX + dx;
                    var nextY = currentY + dy;
                    var terrain = map[nextX + offset, nextY + offset];

                    if (seen[offset + nextX, offset + nextY])
                    {
                        continue;
                    }
                    else if (terrain == 'G')
                    {
                        return currentDistance + 1;
                    }
                    else if (terrain == '.')
                    {
                        todo.Enqueue((nextX, nextY, currentDistance + 1));
                        seen[offset + nextX, offset + nextY] = true;
                    }
                }
            }

            return -1;
        }
    }
}
