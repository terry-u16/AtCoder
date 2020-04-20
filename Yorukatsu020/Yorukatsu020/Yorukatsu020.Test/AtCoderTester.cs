using System;
using Xunit;
using Yorukatsu020.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu020.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"29
20
7
35
120", @"215")]
        [InlineData(@"101
86
119
108
57", @"481")]
        [InlineData(@"123
123
123
123
123", @"643")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"0 5", @"5")]
        [InlineData(@"1 11", @"1100")]
        [InlineData(@"2 85", @"850000")]
        [InlineData(@"0 100", @"101")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 2
1 1 2 2 5", @"1")]
        [InlineData(@"4 4
1 1 2 2", @"0")]
        [InlineData(@"10 3
5 1 3 2 4 1 1 2 3 4", @"3")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
1 5
2 4
3 6", @"3")]
        [InlineData(@"3
1 1 1
2 2 2
3 3 3", @"27")]
        [InlineData(@"6
3 14 159 2 6 53
58 9 79 323 84 6
2643 383 2 79 50 288", @"87")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1 3 2", @"1")]
        [InlineData(@"1 3 1", @"2")]
        [InlineData(@"2 3 3", @"1")]
        [InlineData(@"2 3 1", @"5")]
        [InlineData(@"7 1 1", @"1")]
        [InlineData(@"15 8 5", @"437760187")]
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
