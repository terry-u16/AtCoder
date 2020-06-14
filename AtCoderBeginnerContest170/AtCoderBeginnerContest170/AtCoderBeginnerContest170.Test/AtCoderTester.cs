using System;
using Xunit;
using AtCoderBeginnerContest170.Questions;
using System.Collections.Generic;
using System.Linq;
using AtCoderBeginnerContest170.Collections;

namespace AtCoderBeginnerContest170.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"0 2 3 4 5", @"1")]
        [InlineData(@"1 2 0 4 5", @"3")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 8", @"Yes")]
        [InlineData(@"2 100", @"No")]
        [InlineData(@"1 2", @"Yes")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6 5
4 7 10 6 5", @"8")]
        [InlineData(@"10 5
4 7 10 6 5", @"9")]
        [InlineData(@"100 0", @"100")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
24 11 8 3 16", @"3")]
        [InlineData(@"4
5 5 5 5", @"0")]
        [InlineData(@"10
33 18 45 28 8 19 89 86 2 4", @"5")]
        [InlineData(@"10
1 18 45 28 8 19 89 86 2 4", @"1")]
        [InlineData(@"3
3 1000000 500000", @"2")]
        [InlineData(@"3
1 1 2", @"0")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6 3
8 1
6 2
9 3
1 1
2 2
1 3
4 3
2 1
1 2", @"6
2
6")]
        [InlineData(@"2 2
4208 1234
3056 5678
1 2020
2 2020", @"3056
4208")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 5 2
3 2 3 4
.....
.@..@
..@..", @"5")]
        [InlineData(@"1 6 4
1 1 1 6
......", @"2")]
        [InlineData(@"3 3 1
2 1 2 3
.@.
.@.
.@.", @"-1")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        void AssertNearlyEqual(IEnumerable<string> expected, IEnumerable<string> actual, double acceptableError = 1e-6)
        {
            Assert.Equal(expected.Count(), actual.Count());
            foreach (var (exp, act) in (expected, actual).Zip().Select(p => (double.Parse(p.v1), double.Parse(p.v2))))
            {
                var error = act - exp;
                Assert.InRange(Math.Abs(error), 0, acceptableError);
            }
        }

        IEnumerable<string> SplitByNewLine(string input) => input?.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None) ?? new string[0];
    }
}
