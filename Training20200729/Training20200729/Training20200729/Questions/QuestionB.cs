using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200729.Algorithms;
using Training20200729.Collections;
using Training20200729.Extensions;
using Training20200729.Numerics;
using Training20200729.Questions;

namespace Training20200729.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        const int BoardSize = 19;
        Stone[,] board;
        Direction[,] seen;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            board = new Stone[BoardSize, BoardSize];
            seen = new Direction[BoardSize, BoardSize];
            var blackCount = 0;
            var whiteCount = 0;

            for (int row = 0; row < BoardSize; row++)
            {
                var b = inputStream.ReadLine();
                blackCount += b.Count(c => c == 'o');
                whiteCount += b.Count(c => c == 'x');
                for (int column = 0; column < b.Length; column++)
                {
                    board[row, column] = b[column] switch
                    {
                        'o' => Stone.Black,
                        'x' => Stone.White,
                        _ => Stone.None
                    };
                }
            }

            var blackLine = new List<int>();
            var whiteLine = new List<int>();

            for (int row = 0; row < BoardSize; row++)
            {
                for (int column = 0; column < BoardSize; column++)
                {
                    if (board[row, column] == Stone.Black || board[row, column] == Stone.White)
                    {
                        for (int dir = 0; dir < 4; dir++)
                        {
                            var direction = (Direction)(1 << dir);
                            var line = Search(row, column, board[row, column], direction);
                            if (line >= 5)
                            {
                                if (board[row, column] == Stone.Black)
                                {
                                    blackLine.Add(line);
                                }
                                else
                                {
                                    whiteLine.Add(line);
                                }
                            }
                        }
                    }
                }
            }

            if (blackLine.Count + whiteLine.Count > 1 || blackLine.Any(l => l >= 10) || whiteLine.Any(l => l >= 10))
            {
                yield return "NO";
            }
            else if (blackLine.Count == 1)
            {
                yield return blackCount == whiteCount + 1 ? "YES" : "NO";
            }
            else if (whiteLine.Count == 1)
            {
                yield return blackCount == whiteCount ? "YES" : "NO";
            }
            else
            {
                yield return blackCount == whiteCount || blackCount == whiteCount + 1 ? "YES" : "NO";
            }
        }

        int Search(int row, int column, Stone stone, Direction direction)
        {
            seen[row, column] |= direction;
            var nextRow = direction switch
            {
                Direction.FourThirty => row + 1,
                Direction.Six => row + 1,
                Direction.SevenThirty => row + 1,
                _ => row
            };
            var nextColumn = direction switch
            {
                Direction.Three => column + 1,
                Direction.FourThirty => column + 1,
                Direction.SevenThirty => column - 1,
                _ => column
            };

            if (unchecked((uint)nextRow < BoardSize && (uint)nextColumn < BoardSize) && 
                (seen[nextRow, nextColumn] & direction) == 0 && 
                board[nextRow, nextColumn] == stone)
            {
                return Search(nextRow, nextColumn, stone, direction) + 1;
            }
            else
            {
                return 1;
            }
        }

        enum Stone
        {
            None,
            Black,
            White
        }

        [Flags]
        enum Direction
        {
            Three = 0b0001,
            FourThirty = 0b0010,
            Six = 0b0100,
            SevenThirty = 0b1000
        }
    }
}
