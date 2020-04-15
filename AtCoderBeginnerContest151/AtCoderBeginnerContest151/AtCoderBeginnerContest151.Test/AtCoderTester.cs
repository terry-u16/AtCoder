using System;
using Xunit;
using AtCoderBeginnerContest151.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest151.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"a", @"b")]
        [InlineData(@"y", @"z")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 10 7
8 10 3 6", @"8")]
        [InlineData(@"4 100 60
100 100 100", @"0")]
        [InlineData(@"4 100 60
0 0 0", @"-1")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 5
1 WA
1 AC
2 WA
2 AC
2 WA", @"2 2")]
        [InlineData(@"100000 3
7777 AC
7777 AC
7777 AC", @"1 0")]
        [InlineData(@"6 0", @"0 0")]
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
        [InlineData(@"20 20
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................
....................", @"38")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 2
1 1 3 4", @"11")]
        [InlineData(@"6 3
10 10 10 -10 -10 -10", @"360")]
        [InlineData(@"3 1
1 1 1", @"0")]
        [InlineData(@"10 6
1000000000 1000000000 1000000000 1000000000 1000000000 0 0 0 0 0", @"999998537")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE_Review();

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
