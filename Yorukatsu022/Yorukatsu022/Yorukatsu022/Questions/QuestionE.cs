using Yorukatsu022.Questions;
using Yorukatsu022.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Messaging;

namespace Yorukatsu022.Questions
{
    /// <summary>
    /// ARC074 C
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abcdef = inputStream.ReadIntArray();
            var a = abcdef[0];
            var b = abcdef[1];
            var c = abcdef[2];
            var d = abcdef[3];
            var e = abcdef[4];
            var f = abcdef[5];

            var maxA = f / (100 * a);
            var maxB = f / (100 * b);
            var maxC = (f / 2) / c;
            var maxD = (f / 2) / d;

            var maxSugar = 0;
            var maxWater = 0;
            var maxDensity = -1.0;

            for (int i = 0; i <= maxA; i++)
            {
                for (int j = 0; j <= maxB; j++)
                {
                    var water = 100 * a * i + 100 * b * j;
                    if (water == 0)
                    {
                        continue;
                    }
                    if (water >= f)
                    {
                        break;
                    }

                    for (int k = 0; k <= maxC; k++)
                    {
                        var sugar = c * k;
                        if (water + sugar > f || water * e / 100 < sugar)
                        {
                            break;
                        }

                        for (int l = 0; l <= maxD; l++)
                        {
                            sugar = c * k + d * l;
                            if (water + sugar > f || water * e / 100 < sugar)
                            {
                                break;
                            }
                            var density = 100.0 * sugar / (water + sugar);

                            if (density > maxDensity)
                            {
                                maxWater = water;
                                maxSugar = sugar;
                                maxDensity = density;
                            }
                        }
                    }
                }
            }

            yield return $"{maxWater + maxSugar} {maxSugar}";
        }

        private bool CanSolvable(int water, int sugar, int e) => water * e >= sugar;

        public static void UpdateWhenSmall<T>(ref T value, T other) where T : IComparable<T>
        {
            if (other.CompareTo(value) < 0)
            {
                value = other;
            }
        }

        public static void UpdateWhenLarge<T>(ref T value, T other) where T : IComparable<T>
        {
            if (other.CompareTo(value) > 0)
            {
                value = other;
            }
        }
    }
}
