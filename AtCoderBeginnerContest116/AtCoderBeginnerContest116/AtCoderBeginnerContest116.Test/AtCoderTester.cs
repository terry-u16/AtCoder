using System;
using Xunit;
using AtCoderBeginnerContest116.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest116.Test
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
        [InlineData(@"8", @"5")]
        [InlineData(@"7", @"18")]
        [InlineData(@"54", @"114")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
1 2 2 1", @"2")]
        [InlineData(@"5
3 1 2 3 1", @"5")]
        [InlineData(@"8
4 23 75 0 23 96 50 100", @"221")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 3
1 9
1 7
2 6
2 5
3 1", @"26")]
        [InlineData(@"7 4
1 1
2 1
3 1
4 6
4 5
4 5
4 5", @"25")]
        [InlineData(@"6 5
5 1000000000
2 990000000
3 980000000
6 970000000
6 960000000
4 950000000", @"4900000016")]
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
