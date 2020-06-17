using System;
using Xunit;
using Kujikatsu003.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Kujikatsu003.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"1 3", @"Yes")]
        [InlineData(@"2 4", @"No")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"20 2 5", @"84")]
        [InlineData(@"10 1 2", @"13")]
        [InlineData(@"100 4 16", @"4554")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

[Theory]
[InlineData(@"BBW", @"2")]
[InlineData(@"BWBWBW", @"6")]        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
2 4 4 0 2", @"4")]
        [InlineData(@"7
6 4 0 2 4 0 2", @"0")]
        [InlineData(@"8
7 5 1 1 7 3 5 3", @"16")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 2
1 4
2 5", @"1")]
        [InlineData(@"9 5
1 8
2 7
3 5
4 6
7 9", @"2")]
        [InlineData(@"5 10
1 2
1 3
1 4
1 5
2 3
2 4
2 5
3 4
3 5
4 5", @"4")]
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
