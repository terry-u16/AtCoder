using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu012.Algorithms;
using Kujikatsu012.Collections;
using Kujikatsu012.Extensions;
using Kujikatsu012.Numerics;
using Kujikatsu012.Questions;

namespace Kujikatsu012.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc051/tasks/abc051_c
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (sx, sy, tx, ty) = inputStream.ReadValue<int, int, int, int>();
            var goCount = 0;
            var backCount = 0;

            var x = sx;
            var y = sy;

            var queue = new Queue<char>();

            while (backCount < 2)
            {
                if (goCount == 0 && backCount == 0)
                {
                    if (y < ty)
                    {
                        y++;
                        queue.Enqueue('U');
                    }
                    else
                    {
                        x++;
                        queue.Enqueue('R');
                        if (x == tx)
                        {
                            goCount++;
                        }
                    }
                }
                else if (goCount == 1 && backCount == 0)
                {
                    if (y > sy)
                    {
                        y--;
                        queue.Enqueue('D');
                    }
                    else
                    {
                        x--;
                        queue.Enqueue('L');
                        if (x == sx)
                        {
                            backCount++;
                        }
                    }
                }
                else if (goCount == 1 && backCount == 1)
                {
                    if (y <= ty)
                    {
                        if (x == sx)
                        {
                            x--;
                            queue.Enqueue('L');
                        }
                        else
                        {
                            y++;
                            queue.Enqueue('U');
                        }
                    }
                    else if (x < tx)
                    {
                        x++;
                        queue.Enqueue('R');
                    }
                    else
                    {
                        y--;
                        queue.Enqueue('D');
                        if (y == ty)
                        {
                            goCount++;
                        }
                    }
                }
                else
                {
                    if (y >= sy)
                    {
                        if (x == tx)
                        {
                            x++;
                            queue.Enqueue('R');
                        }
                        else
                        {
                            y--;
                            queue.Enqueue('D');
                        }
                    }
                    else if (x > sx)
                    {
                        x--;
                        queue.Enqueue('L');
                    }
                    else
                    {
                        y++;
                        queue.Enqueue('U');
                        if (y == sy)
                        {
                            backCount++;
                        }
                    }
                }
            }

            yield return string.Concat(queue);
        }
    }
}
