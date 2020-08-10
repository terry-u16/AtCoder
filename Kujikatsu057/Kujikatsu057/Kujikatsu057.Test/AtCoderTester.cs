using System;
using Xunit;
using Kujikatsu057.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu057.Collections;

namespace Kujikatsu057.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"2 11 4", @"4")]
        [InlineData(@"3 9 5", @"3")]
        [InlineData(@"100 1 10", @"0")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
5 2 4", @"3")]
        [InlineData(@"4
631 577 243 199", @"0")]
        [InlineData(@"10
2184 2126 1721 1800 1024 2528 3360 1945 1280 1776", @"39")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 3
1 2 2 4 5", @"7.000000000000")]
        [InlineData(@"4 1
6 6 6 6", @"3.500000000000")]
        [InlineData(@"10 4
17 13 13 12 15 20 10 13 17 11", @"32.000000000000")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            AssertNearlyEqual(outputs, answers);
        }

        [Theory]
        [InlineData(@"1000 8
1 3 4 5 6 7 8 9", @"2000")]
        [InlineData(@"9999 1
0", @"9999")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
7 6 8", @"2")]
        [InlineData(@"3
12 15 18", @"6")]
        [InlineData(@"2
1000000000 1000000000", @"1000000000")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 2
3
5
2
7", @"29")]
        [InlineData(@"4 3
2
4
8
1
2
9
3", @"60")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3 1
3 2", @"2")]
        [InlineData(@"10 10 14
4 3
2 2
7 3
9 10
7 7
8 1
10 10
5 4
3 4
2 8
6 4
4 4
5 8
9 2", @"6")]
        [InlineData(@"100000 100000 0", @"100000")]
        public void QuestionGTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionG();

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
