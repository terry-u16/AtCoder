using System;
using Xunit;
using AtCoderBeginnerContest152.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest152.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"3 3", @"Yes")]
        [InlineData(@"3 2", @"No")]
        [InlineData(@"1 1", @"Yes")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 3", @"3333")]
        [InlineData(@"7 7", @"7777777")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
4 2 5 1 3", @"3")]
        [InlineData(@"4
4 3 2 1", @"4")]
        [InlineData(@"6
1 2 3 4 5 6", @"1")]
        [InlineData(@"8
5 7 4 2 6 8 1 3", @"4")]
        [InlineData(@"1
1", @"1")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"25", @"17")]
        [InlineData(@"1", @"1")]
        [InlineData(@"100", @"108")]
        [InlineData(@"2020", @"40812")]
        [InlineData(@"200000", @"400000008")]
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
        public void QuestionE_ReviewTest(string input, string output)
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
