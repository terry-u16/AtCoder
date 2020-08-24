using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200824.Algorithms;
using Training20200824.Collections;
using Training20200824.Extensions;
using Training20200824.Numerics;
using Training20200824.Questions;

namespace Training20200824.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc149/tasks/abc149_d
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        const int Rock = 0;
        const int Scissors = 1;
        const int Paper = 2;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (jankenCount, restriction) = inputStream.ReadValue<int, int>();
            var winPoints = inputStream.ReadIntArray();
            var pattern = inputStream.ReadLine().Select(c => ToHand(c)).ToArray();

            var totalPoints = 0;

            for (int mod = 0; mod < restriction; mod++)
            {
                var subJankens = (jankenCount - mod + restriction - 1) / restriction;
                var points = new int[subJankens + 1, 3];

                for (int round = 0; round < subJankens; round++)
                {
                    var index = round * restriction + mod;
                    for (int before = Rock; before <= Paper; before++)
                    {
                        for (int current = Rock; current <= Paper; current++)
                        {
                            if (before != current)
                            {
                                AlgorithmHelpers.UpdateWhenLarge(ref points[round + 1, current],
                                    points[round, before] + (Wins(current, pattern[index]) ? winPoints[current] : 0));
                            }
                        }
                    }
                }

                var total = 0;

                for (int hand = Rock; hand <= Paper; hand++)
                {
                    total = Math.Max(total, points[subJankens, hand]);
                }

                totalPoints += total;
            }

            yield return totalPoints;
        }

        bool Wins(int me, int enemy) => (me - enemy + 3) % 3 == 2;

        int ToHand(char c)
        {
            switch (c)
            {
                case 'r':
                    return Rock;
                case 's':
                    return Scissors;
                case 'p':
                    return Paper;
                default:
                    return -1;
            }
        }
    }
}
