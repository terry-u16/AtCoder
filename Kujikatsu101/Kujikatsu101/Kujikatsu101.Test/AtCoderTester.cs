using System;
using Xunit;
using Kujikatsu101.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu101.Collections;

namespace Kujikatsu101.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"5
4 4 9 7 5", @"5")]
        [InlineData(@"6
4 5 4 3 3 5", @"8")]
        [InlineData(@"10
9 4 6 1 9 6 10 6 6 8", @"39")]
        [InlineData(@"2
1 1", @"0")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 2", @"18")]
        [InlineData(@"3 -1", @"0")]
        [InlineData(@"30 -50", @"-1044")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
2
3", @"6")]
        [InlineData(@"5
2
5
10
1000000000000000000
1000000000000000000", @"1000000000000000000")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6 2 1001", @"1369")]
        [InlineData(@"1000 2 16", @"6")]
        [InlineData(@"10000000000 10 99959", @"492443256176507")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3
1 2 1
1 3 1
2 3 3", @"1")]
        [InlineData(@"3 2
1 2 1
2 3 1", @"0")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
3 2 2 3 3", @"Possible")]
        [InlineData(@"3
1 1 2", @"Impossible")]
        [InlineData(@"10
1 2 2 2 2 2 2 2 2 2", @"Possible")]
        [InlineData(@"10
1 1 2 2 2 2 2 2 2 2", @"Impossible")]
        [InlineData(@"6
1 1 1 1 1 5", @"Impossible")]
        [InlineData(@"5
4 3 2 3 4", @"Possible")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3
1 2 1
2 3 1
3 1 2", @"1")]
        [InlineData(@"8 11
1 3 1
1 4 2
2 3 1
2 5 1
3 4 3
3 6 3
3 7 3
4 8 4
5 6 1
6 7 5
7 8 5", @"2")]
        [InlineData(@"2 0", @"-1")]
        [InlineData(@"10 11
1 2 1
2 3 1
3 4 1
4 5 1
5 6 1
6 7 1
7 8 1
8 9 1
9 10 1
1 9 2
9 10 3", @"1")]
        public void QuestionHTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionH();

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
