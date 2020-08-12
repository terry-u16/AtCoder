using System;
using Xunit;
using Kujikatsu059.Questions;
using System.Collections.Generic;
using System.Linq;
using Kujikatsu059.Collections;

namespace Kujikatsu059.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"3 7", @"5 6 7 8 9")]
        [InlineData(@"4 0", @"-3 -2 -1 0 1 2 3")]
        [InlineData(@"1 100", @"100")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
IIDID", @"2")]
        [InlineData(@"7
DDIDDII", @"0")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"7
100 130 130 130 115 115 150", @"1685")]
        [InlineData(@"6
200 180 160 140 120 100", @"1000")]
        [InlineData(@"2
157 193", @"1216")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3", @"4")]
        [InlineData(@"6", @"30")]
        [InlineData(@"1000", @"972926972")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3
...
.#.
...", @"2")]
        [InlineData(@"6 6
..#..#
......
#..#..
......
.#....
....#.", @"3")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
3
2
5", @"3")]
        [InlineData(@"15
3
1
4
1
5
9
2
6
5
3
5
8
9
7
9", @"18")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"eel", @"1")]
        [InlineData(@"ataatmma", @"4")]
        [InlineData(@"snuke", @"-1")]
        [InlineData(@"aaaaazzzz", @"10")]
        [InlineData(@"aaaazzzz", @"8")]
        [InlineData(@"a", @"0")]
        [InlineData(@"azzzaaaz", @"3")]
        [InlineData(@"abcab", @"1")]
        [InlineData(@"ccc", @"0")]
        [InlineData(@"aazzz", @"3")]
        [InlineData(@"zzzaa", @"3")]
        [InlineData(@"zzaac", @"4")]
        [InlineData(@"sgie", @"-1")]
        [InlineData(@"aacbb", @"4")]
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
