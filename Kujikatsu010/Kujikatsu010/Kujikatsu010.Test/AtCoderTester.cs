using System;
using Xunit;
using Kujikatsu010.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu010.Collections;

namespace Kujikatsu010.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"-13 3", @"-10")]
        [InlineData(@"1 -33", @"34")]
        [InlineData(@"13 3", @"39")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"7 5 1", @"YES")]
        [InlineData(@"2 2 1", @"NO")]
        [InlineData(@"1 100 97", @"YES")]
        [InlineData(@"40 98 58", @"YES")]
        [InlineData(@"77 42 36", @"NO")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 2", @"0")]
        [InlineData(@"1 7", @"5")]
        [InlineData(@"314 1592", @"496080")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"575", @"4")]
        [InlineData(@"3600", @"13")]
        [InlineData(@"999999999", @"26484")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6
ooxoox", @"SSSWWS")]
        [InlineData(@"3
oox", @"-1")]
        [InlineData(@"10
oxooxoxoox", @"SSWWSSSWWS")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3 10
1 2 20
2 3 30
1 3 45", @"35")]
        [InlineData(@"2 2 10
1 2 100
2 2 100", @"-1")]
        [InlineData(@"4 5 10
1 2 1
1 4 1
3 4 1
2 2 100
3 3 100", @"0")]
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
