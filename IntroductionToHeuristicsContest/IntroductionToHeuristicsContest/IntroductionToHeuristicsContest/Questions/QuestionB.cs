using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using IntroductionToHeuristicsContest.Algorithms;
using IntroductionToHeuristicsContest.Collections;
using IntroductionToHeuristicsContest.Extensions;
using IntroductionToHeuristicsContest.Numerics;
using IntroductionToHeuristicsContest.Questions;

namespace IntroductionToHeuristicsContest.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var maxDate = inputStream.ReadInt();
            var unhappinessRates = inputStream.ReadLongArray();
            var satisfactions = new long[maxDate][];
            for (int i = 0; i < satisfactions.Length; i++)
            {
                satisfactions[i] = inputStream.ReadLongArray();
            }

            var contests = new int[maxDate];
            for (int i = 0; i < maxDate; i++)
            {
                contests[i] = inputStream.ReadInt() - 1;
            }

            var calculator = new ScoreCalculator(maxDate, unhappinessRates, satisfactions);

            foreach (var score in calculator.CalculateScore(contests))
            {
                yield return score;
            }
        }

        public class ScoreCalculator
        {
            public int MaxDate { get; }
            public long[] UnhappinessRates { get; }
            public long[][] Satisfactions { get; }

            public ScoreCalculator(int maxDate, long[] unhappinessRates, long[][] satisfactions)
            {
                MaxDate = maxDate;
                UnhappinessRates = unhappinessRates;
                Satisfactions = satisfactions;
            }

            public IEnumerable<long> CalculateScore(int[] contests)
            {
                if (contests.Length != MaxDate)
                {
                    throw new ArgumentException();
                }

                var lastHeldDates = Enumerable.Repeat(-1, 26).ToArray();
                long sum = 0;

                for (int date = 0; date < contests.Length; date++)
                {
                    sum += Satisfactions[date][contests[date]];
                    lastHeldDates[contests[date]] = date;

                    for (int contest = 0; contest < UnhappinessRates.Length; contest++)
                    {
                        sum -= UnhappinessRates[contest] * (date - lastHeldDates[contest]);
                    }

                    yield return sum;
                }
            }
        }
    }
}
