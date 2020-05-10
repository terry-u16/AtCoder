using AtCoderBeginnerContest167.Algorithms;
using AtCoderBeginnerContest167.Collections;
using AtCoderBeginnerContest167.Questions;
using AtCoderBeginnerContest167.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace AtCoderBeginnerContest167.Questions
{
    /// <summary>
    /// コンテスト後復習
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var leftQueue = new PriorityQueue<Bracket>(true);
            var rightQueue = new PriorityQueue<Bracket>(true);

            var n = inputStream.ReadInt();
            for (int i = 0; i < n; i++)
            {
                var s = inputStream.ReadLine();
                var leftBrackets = s.Count(c => c == '(');
                var rightBrackets = s.Count(c => c == ')');

                var lowest = 0;
                var height = 0;
                foreach (var c in s)
                {
                    if (c == '(')
                    {
                        lowest = Math.Min(lowest, ++height);
                    }
                    else
                    {
                        lowest = Math.Min(lowest, --height);
                    }
                }

                if (height >= 0)
                {
                    leftQueue.Enqueue(new Bracket(height, lowest));
                }
                else
                {
                    rightQueue.Enqueue(new Bracket(-height, lowest - height));
                }
            }

            if (CheckNotUnderZero(leftQueue, out var left) && CheckNotUnderZero(rightQueue, out var right) && left == right)
            {
                yield return "Yes";
            }
            else
            {
                yield return "No";
            }
        }

        private static bool CheckNotUnderZero(IEnumerable<Bracket> brackets, out int lastHeight)
        {
            var height = 0;
            foreach (var bracket in brackets)
            {
                var lowest = height + bracket.Lowest;

                if (lowest < 0)
                {
                    lastHeight = lowest;
                    return false;
                }
                height += bracket.LastHeight;
            }

            lastHeight = height;
            return true;
        }

        struct Bracket : IComparable<Bracket>
        {
            public int LastHeight { get; }
            public int Lowest { get; }


            public Bracket(int lastHeight, int lowest)
            {
                LastHeight = lastHeight;
                Lowest = lowest;
            }

            public override string ToString() => $"LastHeight:{LastHeight}, Lowest:{Lowest}";

            public int CompareTo([AllowNull] Bracket other) => Lowest.CompareTo(other.Lowest);
        }
    }
}
