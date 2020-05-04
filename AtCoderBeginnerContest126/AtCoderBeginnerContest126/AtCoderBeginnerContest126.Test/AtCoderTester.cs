using System;
using Xunit;
using AtCoderBeginnerContest126.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest126.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"3 1
ABC", @"aBC")]
        [InlineData(@"4 3
CABA", @"CAbA")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1905", @"YYMM")]
        [InlineData(@"0112", @"AMBIGUOUS")]
        [InlineData(@"1700", @"NA")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 10", @"0.145833333333")]
        [InlineData(@"100000 5", @"0.999973749998")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1 2 2
2 3 1", @"0
0
1")]
        [InlineData(@"5
2 5 2
2 3 10
1 3 8
3 4 2", @"1
0
1
0
1")]
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
