using System;
using Xunit;
using Yorukatsu029.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu029.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"3 6
3 4 5", @"2")]
        [InlineData(@"4 9
3 3 3 3", @"4")]
        [InlineData(@"1 100
1", @"2")]
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
        [InlineData(@"4 6
#..#..
.....#
....#.
#.#...", @"8")]
        [InlineData(@"8 8
..#...#.
....#...
##......
..###..#
...#..#.
##....#.
#...#...
###.#..#", @"13")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
2 3 4", @"13")]
        [InlineData(@"5
12 12 12 12 12", @"5")]
        [InlineData(@"3
1000000 999999 999998", @"996989508")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 2 2
1 2 3 4 5", @"4.500000
1")]
        [InlineData(@"4 2 3
10 20 10 10", @"15.000000
3")]
        [InlineData(@"5 1 5
1000000000000000 999999999999999 999999999999998 999999999999997 999999999999996", @"1000000000000000.000000
1")]
        [InlineData(@"50 1 50
1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1", @"1.000000
1125899906842623")]
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
