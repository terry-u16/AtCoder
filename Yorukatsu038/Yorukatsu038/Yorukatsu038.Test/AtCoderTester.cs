using System;
using Xunit;
using Yorukatsu038.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu038.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"kyoto
tokyo", @"Yes")]
        [InlineData(@"abc
arc", @"No")]
        [InlineData(@"aaaaaaaaaaaaaaab
aaaaaaaaaaaaaaab", @"Yes")]
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
        [InlineData(@"2020 2040", @"2")]
        [InlineData(@"4 5", @"20")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"erasedream", @"YES")]
        [InlineData(@"dreameraser", @"YES")]
        [InlineData(@"dreamerer", @"NO")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"0", @"4
3 3 3 3")]
        [InlineData(@"1", @"3
1 0 3")]
        [InlineData(@"2", @"2
2 2")]
        [InlineData(@"3", @"7
27 0 0 0 0 0 0")]
        [InlineData(@"1234567894848", @"10
1000 193 256 777 0 1 1192 1234567891011 48 425")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4", @"8 10
1 2 0
2 3 0
3 4 0
1 5 0
2 6 0
3 7 0
4 8 0
5 6 1
6 7 1
7 8 1")]
        [InlineData(@"5", @"5 7
1 2 0
2 3 1
3 4 0
4 5 0
2 4 0
1 3 3
3 5 1")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        IEnumerable<string> SplitByNewLine(string input) => input?.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None) ?? new string[0];
    }
}
