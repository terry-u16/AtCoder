using System;
using Xunit;
using Kujikatsu009.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu009.Collections;

namespace Kujikatsu009.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"8 6", @"Alice")]
        [InlineData(@"1 1", @"Draw")]
        [InlineData(@"13 1", @"Bob")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"pot
top", @"YES")]
        [InlineData(@"tab
bet", @"NO")]
        [InlineData(@"eye
eel", @"NO")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4", @"1
3")]
        [InlineData(@"7", @"1
2
4")]
        [InlineData(@"1", @"1")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 2 5
1 2 5 7", @"11")]
        [InlineData(@"7 1 100
40 43 45 105 108 115 124", @"84")]
        [InlineData(@"7 1 2
24 35 40 68 72 99 103", @"12")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 2
5 3 1 4 2
1 3
5 4", @"2")]
        [InlineData(@"3 2
3 2 1
1 2
2 3", @"3")]
        [InlineData(@"10 8
5 3 6 8 7 10 9 1 2 4
3 1
4 1
5 9
2 5
6 5
3 5
8 9
7 9", @"8")]
        [InlineData(@"5 1
1 2 3 4 5
1 5", @"5")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 2 3", @"1")]
        [InlineData(@"5
3 11 14 5 13", @"2")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 3
1 2 1 10
1 3 2 20
2 4 4 30
5 2 1 40
1 100 1 4
1 100 1 5
3 1000 3 4", @"130
200
60")]
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
