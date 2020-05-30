using System;
using Xunit;
using VirtualContest20200530.Questions;
using System.Collections.Generic;
using System.Linq;

namespace VirtualContest20200530.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"2
1 1
2 2", @"1")]
        [InlineData(@"3
1 4
4 6
7 8", @"1")]
        [InlineData(@"4
1 1
1 2
2 1
2 2", @"2")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1
1
2", @"1")]
        [InlineData(@"6
3
1
4
2
1
2", @"4")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3
..#
...
#.#", @"9")]
        [InlineData(@"2 5
.#.#.
..#..", @"2")]
        [InlineData(@"6 8
#......#
##....##
#.#..#.#
#..##..#
#......#
#......#", @"182")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 4", @"6")]
        [InlineData(@"5 9", @"20")]
        [InlineData(@"123456789987654321 123456789987654356", @"105728")]
        [InlineData(@"5 5", @"2")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

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
