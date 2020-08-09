using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound663Div2.Extensions;
using CodeforcesRound663Div2.Questions;
using System.Diagnostics;

namespace CodeforcesRound663Div2.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (height, width) = inputStream.ReadValue<int, int>();
            var map = new bool[height][];

            for (int row = 0; row < height; row++)
            {
                map[row] = inputStream.ReadLine().Select(c => c == '1').ToArray();
            }

            if (height >= 4 && width >= 4)
            {
                yield return -1;
            }
            else if (height == 1 || width == 1)
            {
                yield return 0;
            }
            else
            {
                if (height > width)
                {
                    Swap(ref height, ref width);
                    map = Transpose(map);
                }

                const int Inf = 1 << 28;
                var dp = new int[width + 1, 1 << height];
                for (int column = 0; column < width + 1; column++)
                {
                    for (int flag = 0; flag < (1 << height); flag++)
                    {
                        dp[column, flag] = Inf;
                    }
                }
                dp[0, 0] = 0;
                for (int flag = 0; flag < (1 << height); flag++)
                {
                    var op = 0;
                    for (int d = 0; d < height; d++)
                    {
                        if ((((flag & (1 << d)) > 0) ^ map[d][0]))
                        {
                            op++;
                        }
                    }
                    dp[1, flag] = op;
                }

                for (int column = 1; column < width; column++)
                {
                    for (int lastFlag = 0; lastFlag < (1 << height); lastFlag++)
                    {
                        for (int currentFlag = 0; currentFlag < (1 << height); currentFlag++)
                        {
                            var ok = true;
                            for (int row = 0; row + 1 < height; row++)
                            {
                                const int mask = 3;
                                var ones = PopCount((lastFlag >> row) & mask) + PopCount((currentFlag >> row) & mask);
                                ok &= ones % 2 == 1;
                            }

                            if (ok)
                            {
                                var op = 0;
                                for (int row = 0; row < height; row++)
                                {
                                    if ((((currentFlag & (1 << row)) > 0) ^ map[row][column]))
                                    {
                                        op++;
                                    }
                                }
                                dp[column + 1, currentFlag] = Math.Min(dp[column + 1, currentFlag], dp[column, lastFlag] + op);
                                WriteDP(dp, height, width);
                            }
                        }
                    }
                }

                var result = int.MaxValue;
                for (int flag = 0; flag < (1 << height); flag++)
                {
                    result = Math.Min(result, dp[width, flag]);
                }

                yield return result;
            }
        }

        int PopCount(int n)
        {
            var result = 0;
            while (n > 0)
            {
                result += n & 1;
                n >>= 1;
            }
            return result;
        }

        void Swap<T>(ref T a, ref T b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        bool[][] Transpose(bool[][] matrix)
        {
            var height = matrix[0].Length;
            var width = matrix.Length;

            var result = new bool[height][];

            for (int row = 0; row < height; row++)
            {
                result[row] = new bool[width];
                for (int column = 0; column < width; column++)
                {
                    result[row][column] = matrix[column][row];
                }
            }

            return result;
        }

        [Conditional("DEBUG")]
        void WriteDP(int[,] dp, int height, int width)
        {
            for (int flag = 0; flag < (1 << height); flag++)
            {
                for (int column = 0; column < width; column++)
                {
                    Console.Write($"{dp[column, flag],+10} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.Out.Flush();
        }
    }
}
