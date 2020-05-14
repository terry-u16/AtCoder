using System;
using Xunit;
using Yorukatsu039.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu039.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"1 3", @"3")]
        [InlineData(@"0 1", @"0")]
        [InlineData(@"32 21", @"58")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"abaababaab", @"6")]
        [InlineData(@"xxxx", @"2")]
        [InlineData(@"abcabcabcabc", @"6")]
        [InlineData(@"akasakaakasakasakaakas", @"14")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
3 1 3 2", @"1")]
        [InlineData(@"6
105 119 105 119 105 119", @"0")]
        [InlineData(@"4
1 1 1 1", @"2")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
2 2 3 5 5", @"2")]
        [InlineData(@"9
1 2 3 4 5 6 7 8 9", @"0")]
        [InlineData(@"6
6 5 4 3 2 1", @"18")]
        [InlineData(@"7
1 1 1 1 2 3 4", @"6")]
        [InlineData(@"4
1 2 3 4", @"0")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3
1 2 1
2 3 1
1 3 2", @"Yes")]
        [InlineData(@"3 3
1 2 1
2 3 1
1 3 5", @"No")]
        [InlineData(@"4 3
2 1 1
2 3 5
3 4 2", @"Yes")]
        [InlineData(@"10 3
8 7 100
7 9 100
9 8 100", @"No")]
        [InlineData(@"100 0", @"Yes")]
        [InlineData(@"3 3
1 2 -1
2 3 -1
1 3 -2", @"Yes")]
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
