using AtCoderBeginnerContest163.Algorithms;
using AtCoderBeginnerContest163.Collections;
using AtCoderBeginnerContest163.Questions;
using AtCoderBeginnerContest163.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace AtCoderBeginnerContest163.Questions
{
    /// <summary>
    /// ABC163E 復習
    /// </summary>
    public class QuestionEReview : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var infants = inputStream.ReadIntArray().Select((a, index) => new Infant(a, index)).ToArray();

            Array.Sort(infants);
            Array.Reverse(infants);

            var happiness = new long[n + 1, n + 1];     // [left人数, right人数]

            for (int i = 1; i <= n; i++)
            {
                var infant = infants[i - 1];

                for (int leftCount = 0; leftCount <= i; leftCount++)    // left 0人～i人
                {
                    var rightCount = i - leftCount;

                    // 左に配置
                    if (leftCount > 0)
                    {
                        AlgorithmHelpers.UpdateWhenLarge(ref happiness[leftCount, rightCount], happiness[leftCount - 1, rightCount] + infant.GetHappiness(leftCount - 1));  // leftCount=1のとき座標は0
                    }
                    // 右に配置
                    if (rightCount > 0)
                    {
                        AlgorithmHelpers.UpdateWhenLarge(ref happiness[leftCount, rightCount], happiness[leftCount, rightCount - 1] + infant.GetHappiness(infants.Length - rightCount));    // rightCount=1のとき座標はn-1
                    }
                }
            }

            long max = 0;
            for (int leftCount = 0; leftCount <= n; leftCount++)
            {
                var rightCount = n - leftCount;
                AlgorithmHelpers.UpdateWhenLarge(ref max, happiness[leftCount, rightCount]);
            }

            yield return max;
        }

        class Infant : IComparable<Infant>
        {
            public int Briskness { get; }
            public int Position { get; }    // 0-Indexed

            public Infant(int briskness, int position)
            {
                Briskness = briskness;
                Position = position;
            }

            public long GetHappiness(int destination) => (long)Briskness * Math.Abs(Position - destination);

            public int CompareTo([AllowNull] Infant other) => Briskness - other.Briskness;

            public override string ToString() => $"Briskness: {Briskness}, Happiness: {Position}";
        }
    }
}
