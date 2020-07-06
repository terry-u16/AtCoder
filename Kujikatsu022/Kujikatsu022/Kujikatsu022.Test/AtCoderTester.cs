using System;
using Xunit;
using Kujikatsu022.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu022.Collections;

namespace Kujikatsu022.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"1 3", @"2")]
        [InlineData(@"7 4", @"6")]
        [InlineData(@"5 5", @"5")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3", @"6")]
        [InlineData(@"10", @"3628800")]
        [InlineData(@"100000", @"457992974")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"7 1 3 6 7
.#..#..", @"Yes")]
        [InlineData(@"7 1 3 7 6
.#..#..", @"No")]
        [InlineData(@"15 1 3 15 13
...#.#...#.#...", @"Yes")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 4 240
60 90 120
80 150 80 150", @"3")]
        [InlineData(@"3 4 730
60 90 120
80 150 80 150", @"7")]
        [InlineData(@"5 4 1
1000000000 1000000000 1000000000 1000000000 1000000000
1000000000 1000000000 1000000000 1000000000", @"0")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3", @"61")]
        [InlineData(@"4", @"230")]
        [InlineData(@"100", @"388130742")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
)
(()", @"Yes")]
        [InlineData(@"2
)(
()", @"No")]
        [InlineData(@"4
((()))
((((((
))))))
()()()", @"Yes")]
        [InlineData(@"3
(((
)
)", @"No")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
3 2 4 1", @"3 1 2 4")]
        [InlineData(@"2
1 2", @"1 2")]
        [InlineData(@"8
4 6 3 2 8 5 7 1", @"3 1 2 7 4 6 8 5")]
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
