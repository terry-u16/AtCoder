using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200923.Algorithms;
using Training20200923.Collections;
using Training20200923.Numerics;
using Training20200923.Questions;

namespace Training20200923.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var queryCount = io.ReadInt();
            var s = io.ReadString();

            var queries = new Query[queryCount];

            for (int i = 0; i < queries.Length; i++)
            {
                var t = io.ReadString()[0];
                var d = io.ReadString()[0];

                queries[i] = new Query(t, d == 'L' ? Direction.Left : Direction.Right);
            }

            var left = SearchExtensions.BoundaryBinarySearch(FallsLeft, -1, s.Length);
            var right = SearchExtensions.BoundaryBinarySearch(FallsRight, s.Length, -1);

            io.WriteLine(s.Length - (left + 1) - (s.Length - right));

            bool FallsLeft(int index)
            {
                foreach (var query in queries)
                {
                    if (s[index] == query.Char)
                    {
                        if (query.Direction == Direction.Left)
                        {
                            index--;
                        }
                        else
                        {
                            index++;
                        }
                    }

                    if (index < 0)
                    {
                        return true;
                    }
                    else if (index >= s.Length)
                    {
                        return false;
                    }
                }

                return false;
            }

            bool FallsRight(int index)
            {
                foreach (var query in queries)
                {
                    if (s[index] == query.Char)
                    {
                        if (query.Direction == Direction.Left)
                        {
                            index--;
                        }
                        else
                        {
                            index++;
                        }
                    }

                    if (index < 0)
                    {
                        return false;
                    }
                    else if (index >= s.Length)
                    {
                        return true;
                    }
                }

                return false;
            }

        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Query
        {
            public char Char { get; }
            public Direction Direction { get; }

            public Query(char c, Direction direction)
            {
                Char = c;
                Direction = direction;
            }

            public void Deconstruct(out char c, out Direction direction) => (c, direction) = (Char, Direction);
            public override string ToString() => $"{nameof(Char)}: {Char}, {nameof(Direction)}: {Direction}";
        }
        enum Direction
        {
            Left,
            Right
        }
    }
}
