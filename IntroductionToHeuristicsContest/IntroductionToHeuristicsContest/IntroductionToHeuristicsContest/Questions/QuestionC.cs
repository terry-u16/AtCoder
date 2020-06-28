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
using System.Collections.Immutable;

namespace IntroductionToHeuristicsContest.Questions
{
    public class QuestionC : AtCoderQuestionBase
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

            var calculator = new ScoreCalculator(maxDate, unhappinessRates, satisfactions, ImmutableArray.Create(contests));

            var queries = inputStream.ReadInt();
            for (int q = 0; q < queries; q++)
            {
                var (d, aft) = inputStream.ReadValue<int, int>();
                calculator.Update(new Query(d - 1, aft - 1));
                yield return calculator.TotalScore;
            }
        }

        public class ScoreCalculator
        {
            public int MaxDate { get; }
            public long[] UnhappinessRates { get; }
            public long[][] Satisfactions { get; }
            private ImmutableArray<int> _previousSchedule;
            public ImmutableArray<int> Schedule { get; private set; }
            private long _previousScore = 0;
            public long TotalScore { get; private set; }
            public ImmutableArray<long> PreviousScores { get; private set; }
            public ImmutableArray<long> Scores { get; private set; }

            public ScoreCalculator(int maxDate, long[] unhappinessRates, long[][] satisfactions, ImmutableArray<int> contests)
            {
                MaxDate = maxDate;
                UnhappinessRates = unhappinessRates;
                Satisfactions = satisfactions;
                Schedule = contests;
                CalculateScore(contests);
            }

            private void CalculateScore(ImmutableArray<int> contests)
            {
                if (contests.Length != MaxDate)
                {
                    throw new ArgumentException();
                }

                var lastHeldDates = Enumerable.Repeat(-1, 26).ToArray();
                var sum = new long[26];

                for (int date = 0; date < contests.Length; date++)
                {
                    sum[contests[date]] += Satisfactions[date][contests[date]];
                    lastHeldDates[contests[date]] = date;

                    for (int contest = 0; contest < UnhappinessRates.Length; contest++)
                    {
                        sum[contest] -= UnhappinessRates[contest] * (date - lastHeldDates[contest]);
                    }
                }

                TotalScore = sum.Sum();
                Scores = ImmutableArray.Create(sum);
            }

            public long Update(Query query)
            {
                var before = Schedule[query.Date];
                _previousSchedule = Schedule;
                Schedule = Schedule.SetItem(query.Date, query.After);
                _previousScore = TotalScore;
                var (beforeScore, afterScore) = GetScore(before, query.After);
                var diff = (beforeScore - Scores[before]) + (afterScore - Scores[query.After]);
                TotalScore = TotalScore + diff;

                PreviousScores = Scores;
                var builder = Scores.ToBuilder();
                builder[before] = beforeScore;
                builder[query.After] = afterScore;
                Scores = builder.ToImmutable();
                return diff;
            }

            public void Revert()
            {
                Schedule = _previousSchedule;
                Scores = PreviousScores;
                TotalScore = _previousScore;
            }

            (long, long) GetScore(int before, int after)
            {
                long beforeSum = 0;
                long afterSum = 0;
                long beforeLastHeld = -1;
                long afterLastHeld = -1;

                for (int date = 0; date < Schedule.Length; date++)
                {
                    if (Schedule[date] == before)
                    {
                        beforeSum += Satisfactions[date][before];
                        beforeLastHeld = date;
                    }
                    else if (Schedule[date] == after)
                    {
                        afterSum += Satisfactions[date][after];
                        afterLastHeld = date;
                    }

                    beforeSum -= UnhappinessRates[before] * (date - beforeLastHeld);
                    afterSum -= UnhappinessRates[after] * (date - afterLastHeld);
                }

                return (beforeSum, afterSum);
            }
        }

        [StructLayout(LayoutKind.Auto)]
        public readonly struct Query
        {
            public int Date { get; }
            public int After { get; }

            public Query(int date, int after)
            {
                Date = date;
                After = after;
            }

            public override string ToString() => $"{nameof(Date)}: {Date}, {nameof(After)}: {After}";
        }
    }
}
