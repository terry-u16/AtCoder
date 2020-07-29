using System;
using Xunit;
using Kujikatsu045.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu045.Collections;

namespace Kujikatsu045.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"1 + 2", @"3")]
        [InlineData(@"5 - 7", @"-2")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"20 3
5 10 15", @"10")]
        [InlineData(@"20 3
0 5 15", @"10")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"atcoder", @"atcoderb")]
        [InlineData(@"abc", @"abcd")]
        [InlineData(@"zyxwvutsrqponmlkjihgfedcba", @"-1")]
        [InlineData(@"abcdefghijklmnopqrstuvwzyx", @"abcdefghijklmnopqrstuvx")]
        [InlineData(@"abcdefghijklmnopqrstuvwyxz", @"abcdefghijklmnopqrstuvwyz")]
        [InlineData(@"azyxwvutsrqponmlkjihgfedcb", @"b")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 2
#.#
.#.
#.#
#.
.#", @"Yes")]
        [InlineData(@"4 1
....
....
....
....
#", @"No")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
ababa", @"2")]
        [InlineData(@"2
xy", @"0")]
        [InlineData(@"13
strangeorange", @"5")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6 5
1 2
2 3
3 4
4 5
5 6", @"4")]
        [InlineData(@"5 5
1 2
2 3
3 1
5 4
5 1", @"5")]
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
