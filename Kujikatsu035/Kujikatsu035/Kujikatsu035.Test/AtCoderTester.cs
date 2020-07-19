using System;
using Xunit;
using Kujikatsu035.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu035.Collections;

namespace Kujikatsu035.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"5 7 5", @"7")]
        [InlineData(@"1 1 7", @"7")]
        [InlineData(@"-100 100 100", @"-100")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
3 5 2
4 5", @"9")]
        [InlineData(@"3
5 6 3 8
5 100 8", @"22")]
        [InlineData(@"2
100 1 1
1 100", @"3")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
1 2 2 1", @"2")]
        [InlineData(@"5
3 1 2 3 1", @"5")]
        [InlineData(@"8
4 23 75 0 23 96 50 100", @"221")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"xabxa", @"2")]
        [InlineData(@"ab", @"-1")]
        [InlineData(@"a", @"0")]
        [InlineData(@"oxxx", @"3")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 2
4 1 5", @"3")]
        [InlineData(@"13 17
29 7 5 7 9 51 7 13 8 55 42 9 81", @"6")]
        [InlineData(@"10 400000000
1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000", @"25")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 1 1 0 0 0 0", @"3")]
        [InlineData(@"0 0 10 0 0 0 0", @"0")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 1
4 3 2", @"POSSIBLE")]
        [InlineData(@"3
1 2
1 2 3", @"IMPOSSIBLE")]
        [InlineData(@"8
1 1 1 3 4 5 5
4 1 6 2 2 1 3 3", @"POSSIBLE")]
        [InlineData(@"1

0", @"POSSIBLE")]
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
