using System;
using Xunit;
using Kujikatsu099.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu099.Collections;

namespace Kujikatsu099.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"3 5 7", @"10")]
        [InlineData(@"3 2 9", @"6")]
        [InlineData(@"20 20 19", @"0")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 2
1 3
2 4", @"2")]
        [InlineData(@"10 3
3 6
5 7
6 9", @"1")]
        [InlineData(@"100000 1
1 100000", @"100000")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 3
2 3 1 4", @"2")]
        [InlineData(@"3 3
1 2 3", @"1")]
        [InlineData(@"8 3
7 3 1 8 4 6 2 5", @"4")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
2 3 5
2 1 5
1 2 5
3 2 5", @"2 2 6")]
        [InlineData(@"2
0 0 100
1 1 98", @"0 0 100")]
        [InlineData(@"3
99 1 191
100 1 192
99 0 192", @"100 0 193")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3 2
1 2
5 4
9 2", @"2")]
        [InlineData(@"9 4 1
1 5
2 4
3 3
4 2
5 1
6 2
7 3
8 4
9 5", @"5")]
        [InlineData(@"3 0 1
300000000 1000000000
100000000 1000000000
200000000 1000000000", @"3000000000")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 3 7 9 5 4 8 6 2", @"1")]
        [InlineData(@"4
6 7 1 4 13 16 10 9 5 11 12 14 15 2 3 8", @"3")]
        [InlineData(@"6
11 21 35 22 7 36 27 34 8 20 15 13 16 1 24 3 2 17 26 9 18 32 31 23 19 14 4 25 10 29 28 33 12 6 5 30", @"11")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = SplitByNewLine(question.Solve(input).Trim());

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
