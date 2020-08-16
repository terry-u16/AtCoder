using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MSolutions2020.Algorithms;
using MSolutions2020.Collections;
using MSolutions2020.Extensions;
using MSolutions2020.Numerics;
using MSolutions2020.Questions;

namespace MSolutions2020.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();

            var direction = Direction.None;
            long yen = 1000;
            long stocks = 0;
            long lastBuy = 0;

            for (int i = 1; i < a.Length; i++)
            {
                switch (direction)
                {
                    case Direction.None:
                        if (a[i - 1] < a[i])
                        {
                            direction = Direction.Ascending;
                            lastBuy = a[i - 1];
                            stocks = yen / lastBuy;
                            yen -= stocks * lastBuy;
                        }
                        else
                        {
                            direction = Direction.Descending;
                        }
                        break;
                    case Direction.Ascending:
                        if (a[i - 1] > a[i])
                        {
                            direction = Direction.Descending;
                            yen += stocks * a[i - 1];
                            stocks = 0;
                        }
                        break;
                    case Direction.Descending:
                        if (a[i - 1] < a[i])
                        {
                            direction = Direction.Ascending;
                            lastBuy = a[i - 1];
                            stocks = yen / lastBuy;
                            yen -= stocks * lastBuy;
                        }
                        break;
                }
            }

            if (lastBuy > a[^1])
            {
                yen += stocks * lastBuy;
            }
            else
            {
                yen += stocks * a[^1];
            }

            yield return yen;
        }

        enum Direction
        {
            None,
            Ascending,
            Descending
        }
    }
}
