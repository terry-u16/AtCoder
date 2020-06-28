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
using System.Diagnostics;

namespace IntroductionToHeuristicsContest.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        Random random = new Random();
        const int timeLimit = 1850;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var maxDate = inputStream.ReadInt();
            var unhappinessRates = inputStream.ReadIntArray();
            var satisfactions = new int[maxDate][];
            for (int i = 0; i < satisfactions.Length; i++)
            {
                satisfactions[i] = inputStream.ReadIntArray();
            }

            var contests = new int[maxDate];
            var lastDate = Enumerable.Repeat(-1, 26).ToArray();

            for (int date = 0; date < contests.Length; date++)
            {
                var estimated = new int[26];

                for (int i = 0; i < unhappinessRates.Length; i++)
                {
                    var nextUnhappiness = unhappinessRates[i] * (date - lastDate[i]);
                    estimated[i] = satisfactions[date][i] + nextUnhappiness;
                }

                for (int i = 0; i + 1 < estimated.Length; i++)
                {
                    estimated[i + 1] += estimated[i];
                }

                var nextIndex = SearchExtensions.GetGreaterThanIndex(estimated, random.Next(estimated[^1]));
                contests[date] = nextIndex;
            }

            var calculator = new ScoreCalculator(maxDate, unhappinessRates, satisfactions, ImmutableArray.Create(contests));

            while (stopwatch.ElapsedMilliseconds < timeLimit)
            {
                Improve(maxDate, unhappinessRates, satisfactions, calculator);
            }

            for (int date = 0; date < maxDate; date++)
            {
                yield return calculator.Schedule[date] + 1;
            }

#if DEBUG
            yield return calculator.TotalScore;
#endif
        }

        private void Improve(int maxDate, int[] unhappinessRates, int[][] satisfactions, ScoreCalculator calculator)
        {
            var date = random.Next(maxDate);
            Span<int> estimated = stackalloc int[26];

            for (int i = 0; i < unhappinessRates.Length; i++)
            {
                estimated[i] = satisfactions[date][i] + unhappinessRates[i] * 20;
            }

            for (int i = 0; i + 1 < estimated.Length; i++)
            {
                estimated[i + 1] += estimated[i];
            }

            var contest = SearchExtensions.GetGreaterThanIndex(estimated, random.Next(estimated[^1]));
            var query = new Query(date, contest);
            var diff = calculator.Update(query);
            if (diff < 0)
            {
                calculator.Revert();
            }
        }

        public class ScoreCalculator
        {
            public int MaxDate { get; }
            public int[] UnhappinessRates { get; }
            public int[][] Satisfactions { get; }
            private ImmutableArray<int> _previousSchedule;
            public ImmutableArray<int> Schedule { get; private set; }
            private int _previousScore = 0;
            public int TotalScore { get; private set; }
            public ImmutableArray<int> PreviousScores { get; private set; }
            public ImmutableArray<int> Scores { get; private set; }

            public ScoreCalculator(int maxDate, int[] unhappinessRates, int[][] satisfactions, ImmutableArray<int> contests)
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
                var sum = new int[26];

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

            public int Update(Query query)
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

            (int, int) GetScore(int before, int after)
            {
                int beforeSum = 0;
                int afterSum = 0;
                int beforeLastHeld = -1;
                int afterLastHeld = -1;

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
