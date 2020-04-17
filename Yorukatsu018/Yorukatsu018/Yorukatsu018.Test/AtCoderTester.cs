using System;
using Xunit;
using Yorukatsu018.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu018.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"3 4", @"6")]
        [InlineData(@"2 2", @"1")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 4
##.#
....
##.#
.#.#", @"###
###
.##")]
        [InlineData(@"3 3
#..
.#.
..#", @"#..
.#.
..#")]
        [InlineData(@"4 5
.....
.....
..#..
.....", @"#")]
        [InlineData(@"7 6
......
....#.
.#....
..#...
..#...
......
.#..#.", @"..#
#..
.#.
.#.
#.#")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
MASHIKE
RUMOI
OBIRA
HABORO
HOROKANAI", @"2")]
        [InlineData(@"4
ZZ
ZZZ
Z
ZZZZZZZZZZ", @"0")]
        [InlineData(@"5
CHOKUDAI
RNG
MAKOTO
AOKI
RINGO", @"7")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"7 7
1 3
2 7
3 4
4 5
4 6
5 6
6 7", @"4")]
        [InlineData(@"3 3
1 2
1 3
2 3", @"0")]
        [InlineData(@"6 5
1 2
2 3
3 4
4 5
5 6", @"5")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 6
2 1
3 4
4 10
3 4", @"11")]
        [InlineData(@"4 6
2 1
3 7
4 10
3 6", @"13")]
        [InlineData(@"4 10
1 100
1 100
1 100
1 100", @"400")]
        [InlineData(@"4 1
10 100
10 100
10 100
10 100", @"0")]
        [InlineData(@"6 349527488
898044776 244135
898044778 5987199
898044778 1719464
898044777 8760592
898044776 2519161
898044779 1868002", @"0")]

        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"7 7
1 3
2 7
3 4
4 5
4 6
5 6
6 7", @"4")]
        [InlineData(@"3 3
1 2
1 3
2 3", @"0")]
        [InlineData(@"6 5
1 2
2 3
3 4
4 5
5 6", @"5")]
        public void QuestionD_UnionFindTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD_UnionFind();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
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
