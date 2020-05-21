using System;
using Xunit;
using Yorukatsu045.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu045.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"3
1
4
3", @"4
3
4")]
        [InlineData(@"2
5
5", @"5
5")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"10", @"5")]
        [InlineData(@"50", @"13")]
        [InlineData(@"10000000019", @"10000000018")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"BBBWW", @"1")]
        [InlineData(@"WWWWWW", @"0")]
        [InlineData(@"WBWBWBWBWB", @"9")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"10000", @"3")]
        [InlineData(@"1000003", @"7")]
        [InlineData(@"9876543210", @"6")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"needed", @"2 5")]
        [InlineData(@"atcoder", @"-1 -1")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"-2 -2 2 2
1
0 0 1", @"3.6568542495")]
        [InlineData(@"-2 0 2 0
2
-1 0 2
1 0 2", @"0.0000000000")]
        [InlineData(@"4 -2 -2 4
3
0 0 2
4 0 1
0 4 1", @"4.0000000000")]
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
