using System;
using Xunit;
using Kujikatsu024.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu024.Collections;

namespace Kujikatsu024.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"3 4 5", @"6")]
        [InlineData(@"5 12 13", @"30")]
        [InlineData(@"45 28 53", @"630")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3
.#.
###
.#.", @"Yes")]
        [InlineData(@"5 5
#.#.#
.#.#.
#.#.#
.#.#.
#.#.#", @"No")]
        [InlineData(@"11 11
...#####...
.##.....##.
#..##.##..#
#..##.##..#
#.........#
#...###...#
.#########.
.#.#.#.#.#.
##.#.#.#.##
..##.#.##..
.##..#..##.", @"Yes")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
3
2
4
3
5", @"7")]
        [InlineData(@"10
123
123
123
123
123", @"5")]
        [InlineData(@"10000000007
2
3
5
7
11", @"5000000008")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 7
9 3 4", @"POSSIBLE")]
        [InlineData(@"3 5
6 9 3", @"IMPOSSIBLE")]
        [InlineData(@"4 11
11 3 7 15", @"POSSIBLE")]
        [InlineData(@"5 12
10 2 8 6 4", @"IMPOSSIBLE")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 1
1 2 1", @"2")]
        [InlineData(@"6 5
1 2 1
2 3 2
1 3 3
4 5 4
5 6 5", @"2")]
        [InlineData(@"100000 1
1 100000 100", @"99999")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

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
