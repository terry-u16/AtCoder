using System;
using Xunit;
using AtCoderBeginnerContest136.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest136.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"6 4 3", @"1")]
        [InlineData(@"8 3 9", @"4")]
        [InlineData(@"12 3 7", @"0")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"11", @"9")]
        [InlineData(@"136", @"46")]
        [InlineData(@"100000", @"90909")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
1 2 1 1 3", @"Yes")]
        [InlineData(@"4
1 3 2 1", @"No")]
        [InlineData(@"5
1 2 3 4 5", @"Yes")]
        [InlineData(@"1
1000000000", @"Yes")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"RRLRL", @"0 1 2 1 1")]
        [InlineData(@"RRLLLLRLRRLL", @"0 3 3 0 0 0 1 1 0 2 2 0")]
        [InlineData(@"RRRLLRLLRRRLLLLL", @"0 0 3 2 0 2 1 0 0 0 4 4 0 0 0 0")]
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
