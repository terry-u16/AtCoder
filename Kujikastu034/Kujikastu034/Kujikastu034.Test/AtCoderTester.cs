using System;
using Xunit;
using Kujikastu034.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikastu034.Collections;

namespace Kujikastu034.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"15", @"6")]
        [InlineData(@"100000", @"10")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
4 2 5 1 3", @"3")]
        [InlineData(@"4
4 3 2 1", @"4")]
        [InlineData(@"6
1 2 3 4 5 6", @"1")]
        [InlineData(@"8
5 7 4 2 6 8 1 3", @"4")]
        [InlineData(@"1
1", @"1")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 3 2
..#
###", @"5")]
        [InlineData(@"2 3 4
..#
###", @"1")]
        [InlineData(@"2 2 3
##
##", @"0")]
        [InlineData(@"6 6 8
..##..
.#..#.
#....#
######
#....#
#....#", @"208")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3
...
...
...", @"4")]
        [InlineData(@"3 5
...#.
.#.#.
.#...", @"10")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"9 3
0001000100", @"1 3 2 3")]
        [InlineData(@"5 4
011110", @"-1")]
        [InlineData(@"6 6
0101010", @"6")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
2 3 1", @"5")]
        [InlineData(@"5
1 2 3 4 5", @"30")]
        [InlineData(@"8
8 2 7 3 4 5 6 1", @"136")]
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
