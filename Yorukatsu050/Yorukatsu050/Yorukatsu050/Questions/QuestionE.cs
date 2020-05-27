using Yorukatsu050.Questions;
using Yorukatsu050.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu050.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc082/tasks/arc087_b
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var xy = inputStream.ReadIntArray();
            var x = xy[0];
            var y = xy[1];

            List<int> xOrders, yOrders;
            Decode(s, out xOrders, out yOrders);

            var initialX = s.TakeWhile(c => c == 'F').Count();
            if (CheckReachable(initialX, x, xOrders) && CheckReachable(0, y, yOrders))
            {
                yield return "Yes";
            }
            else
            {
                yield return "No";
            }
        }

        private static void Decode(string s, out List<int> xOrders, out List<int> yOrders)
        {
            xOrders = new List<int>();
            yOrders = new List<int>();
            var currentDirection = Direction.X;
            var currentDistance = 0;
            foreach (var c in s.SkipWhile(c => c == 'F'))
            {
                if (c == 'T')
                {
                    currentDirection = AddOrderAndTurn(xOrders, yOrders, currentDirection, currentDistance);
                    currentDistance = 0;
                }
                else
                {
                    currentDistance++;
                }
            }
            AddOrderAndTurn(xOrders, yOrders, currentDirection, currentDistance);
        }

        private static Direction AddOrderAndTurn(List<int> xOrders, List<int> yOrders, Direction currentDirection, int currentDistance)
        {
            switch (currentDirection)
            {
                case Direction.X:
                    xOrders.Add(currentDistance);
                    currentDirection = Direction.Y;
                    break;
                case Direction.Y:
                    yOrders.Add(currentDistance);
                    currentDirection = Direction.X;
                    break;
            }

            return currentDirection;
        }

        bool CheckReachable(int start, int goal, IList<int> orders)
        {
            const int loop = 1 << 14;
            const int mask = (1 << 14) - 1;
            var reachable = new bool[orders.Count + 1, loop];
            reachable[0, start] = true;

            for (int orderIndex = 0; orderIndex < orders.Count; orderIndex++)
            {
                for (int coordinate = 0; coordinate < reachable.GetLength(1); coordinate++)
                {
                    if (reachable[orderIndex, coordinate])
                    {
                        var order = orders[orderIndex];
                        reachable[orderIndex + 1, (coordinate + order) & mask] = true;
                        reachable[orderIndex + 1, (coordinate - order + loop) & mask] = true;
                    }
                }
            }

            return reachable[orders.Count, (goal + loop) & mask];
        }

        enum Direction
        {
            X,
            Y
        }
    }
}
