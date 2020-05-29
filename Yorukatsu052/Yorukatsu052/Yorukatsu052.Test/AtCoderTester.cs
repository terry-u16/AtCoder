using System;
using Xunit;
using Yorukatsu052.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu052.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"ASSA", @"Yes")]
        [InlineData(@"STOP", @"No")]
        [InlineData(@"FFEE", @"Yes")]
        [InlineData(@"FREE", @"No")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"7 5 1", @"YES")]
        [InlineData(@"2 2 1", @"NO")]
        [InlineData(@"1 100 97", @"YES")]
        [InlineData(@"40 98 58", @"YES")]
        [InlineData(@"77 42 36", @"NO")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"a
4
2 1 p
1
2 2 c
1", @"cpa")]
        [InlineData(@"a
6
2 2 a
2 1 b
1
2 2 c
1
1", @"aabc")]
        [InlineData(@"y
1
2 1 x", @"xy")]
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
        [InlineData(@"4 5
1 2
3 4
1 3
2 3
1 4", @"0
0
4
5
6")]
        [InlineData(@"6 5
2 3
1 2
5 6
3 4
4 5", @"8
9
12
14
15")]
        [InlineData(@"2 1
1 2", @"1")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"010", @"2")]
        [InlineData(@"100000000", @"8")]
        [InlineData(@"00001111", @"4")]
        [InlineData(@"1", @"1")]
        [InlineData(@"01", @"1")]
        [InlineData(@"11", @"2")]
        [InlineData(@"11111111", @"8")]
        [InlineData(@"111111111", @"9")]
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
