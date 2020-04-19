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
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var infants = inputStream.ReadIntArray().Select((a, index) => new Infant(a, index)).ToArray();

            Array.Sort(infants);
            Array.Reverse(infants);

            var dpStatus = new DPStatus[n + 1, 2];     // left of right
            dpStatus[0, 0] = new DPStatus(0, 0, infants.Length - 1);
            dpStatus[0, 1] = new DPStatus(0, 0, infants.Length - 1);


            for (int i = 0; i < n; i++)
            {
                var infant = infants[i];

                var beforeLeft = dpStatus[i, 0];
                var beforeRight = dpStatus[i, 1];

                // 左に並べるとき
                AlgorithmHelpers.UpdateWhenLarge(ref dpStatus[i + 1, 0], 
                    new DPStatus(beforeLeft.Happiness + infant.Briskness * Math.Abs(infant.Position - beforeLeft.LeftIndex), beforeLeft.LeftIndex + 1, beforeLeft.RightIndex));
                AlgorithmHelpers.UpdateWhenLarge(ref dpStatus[i + 1, 0],
                    new DPStatus(beforeRight.Happiness + infant.Briskness * Math.Abs(infant.Position - beforeRight.LeftIndex), beforeRight.LeftIndex + 1, beforeRight.RightIndex));


                // 右に並べるとき
                AlgorithmHelpers.UpdateWhenLarge(ref dpStatus[i + 1, 1],
                    new DPStatus(beforeLeft.Happiness + infant.Briskness * Math.Abs(infant.Position - beforeLeft.RightIndex), beforeLeft.LeftIndex, beforeLeft.RightIndex - 1));
                AlgorithmHelpers.UpdateWhenLarge(ref dpStatus[i + 1, 1],
                    new DPStatus(beforeRight.Happiness + infant.Briskness * Math.Abs(infant.Position - beforeRight.RightIndex), beforeRight.LeftIndex, beforeRight.RightIndex - 1));
            }

            yield return Math.Max(dpStatus[n, 0].Happiness, dpStatus[n, 1].Happiness);
        }


        class Infant : IComparable<Infant>
        {
            public int Briskness { get; }
            public int Position { get; }

            public Infant(int briskness, int position)
            {
                Briskness = briskness;
                Position = position;
            }

            public int CompareTo([AllowNull] Infant other) => Briskness - other.Briskness;

            public override string ToString() => $"Briskness: {Briskness}, Happiness: {Position}";
        }

        struct DPStatus : IComparable<DPStatus>
        {
            public long Happiness { get; }
            public int LeftIndex { get; }
            public int RightIndex { get; }

            public DPStatus(long happiness, int leftIndex, int rightIndex)
            {
                Happiness = happiness;
                LeftIndex = leftIndex;
                RightIndex = rightIndex;
            }

            public int CompareTo([AllowNull] DPStatus other) => Happiness.CompareTo(other.Happiness);

            public override string ToString() => $"Happiness: {Happiness}, LeftIndex: {LeftIndex}, RightIndex: {RightIndex}";

        }
    }
}
