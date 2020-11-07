using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PAST001.Algorithms;
using PAST001.Collections;
using PAST001.Numerics;
using PAST001.Questions;

namespace PAST001.Questions
{
    public class QuestionH : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var cards = io.ReadIntArray(n);
            var odds = (n + 1) / 2;

            var oddMin = int.MaxValue;
            var allMin = int.MaxValue;

            for (int i = 0; i < cards.Length; i++)
            {
                var index = i + 1;
                if (index % 2 == 1)
                {
                    oddMin.ChangeMin(cards[i]);
                }
                allMin.ChangeMin(cards[i]);
            }

            var oddSold = 0;
            var allSold = 0;
            long totalSold = 0;

            var queries = io.ReadInt();

            for (int q = 0; q < queries; q++)
            {
                var type = io.ReadInt();

                if (type == 1)
                {
                    var index = io.ReadInt();
                    var a = io.ReadInt();
                    var sold = index % 2 == 1 ? oddSold : 0;
                    sold += allSold;

                    var i = index - 1;
                    if (cards[i] - sold >= a)
                    {
                        totalSold += a;
                        cards[i] -= a;
                        if (index % 2 == 1)
                        {
                            oddMin.ChangeMin(cards[i]);
                        }
                        allMin.ChangeMin(cards[i]);
                    }
                }
                else if (type == 2)
                {
                    var a = io.ReadInt();

                    if (oddMin >= a)
                    {
                        oddSold += a;
                        totalSold += (long)a * odds;
                        oddMin -= a;
                        allMin.ChangeMin(oddMin);
                    }
                }
                else
                {
                    var a = io.ReadInt();

                    if (allMin >= a)
                    {
                        allSold += a;
                        totalSold += (long)a * n;
                        oddMin -= a;
                        allMin -= a;
                    }
                }
            }

            io.WriteLine(totalSold);
        }
    }
}
