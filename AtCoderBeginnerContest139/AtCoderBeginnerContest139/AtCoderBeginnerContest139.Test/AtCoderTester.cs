using System;
using Xunit;
using AtCoderBeginnerContest139.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest139.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"CSS
CSR", @"2")]
        [InlineData(@"SSR
SSR", @"3")]
        [InlineData(@"RRR
SSS", @"0")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 10", @"3")]
        [InlineData(@"8 9", @"2")]
        [InlineData(@"8 8", @"1")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
10 4 8 7 3", @"2")]
        [InlineData(@"7
4 4 5 6 6 5 5", @"3")]
        [InlineData(@"4
1 2 3 4", @"0")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2", @"1")]
        [InlineData(@"13", @"78")]
        [InlineData(@"1", @"0")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
2 3
1 3
1 2", @"3")]
        [InlineData(@"4
2 3 4
1 3 4
4 1 2
3 1 2", @"4")]
        [InlineData(@"3
2 3
3 1
1 2", @"-1")]
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
