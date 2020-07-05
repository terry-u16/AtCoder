using System;
using Xunit;
using Kujikatsu020.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu020.Collections;

namespace Kujikatsu020.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"3 4", @"Even")]
        [InlineData(@"1 21", @"Odd")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"12", @"Yes")]
        [InlineData(@"101", @"No")]
        [InlineData(@"999999999", @"Yes")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 2
1 2
2 3", @"2")]
        [InlineData(@"3 3
1 2
2 3
2 3", @"1")]
        [InlineData(@"4 4
1 2
2 3
4 1
3 4", @"3")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
())", @"(())")]
        [InlineData(@"6
)))())", @"(((()))())")]
        [InlineData(@"8
))))((((", @"(((())))(((())))")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3
1 2
1 3
2 3", @"2")]
        [InlineData(@"7 7
1 3
2 7
3 4
4 5
4 6
5 6
6 7", @"1")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
3 1 4 1 5 9", @"1")]
        [InlineData(@"1
1 2 3", @"-1")]
        [InlineData(@"3
8 2 2 7 4 6 5 3 8", @"5")]
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
