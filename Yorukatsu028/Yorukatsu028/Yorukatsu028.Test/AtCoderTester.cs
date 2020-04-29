using System;
using Xunit;
using Yorukatsu028.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu028.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"+-++", @"2")]
        [InlineData(@"-+--", @"-2")]
        [InlineData(@"----", @"-4")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 4
0 3", @"7")]
        [InlineData(@"2 4
0 5", @"8")]
        [InlineData(@"4 1000000000
0 1000 1000000 1000000000", @"2000000000")]
        [InlineData(@"1 1
0", @"1")]
        [InlineData(@"9 10
0 3 5 7 100 110 200 300 311", @"67")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"7", @"2")]
        [InlineData(@"17", @"3")]
        [InlineData(@"149696127901", @"27217477801")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3
2 2 2", @"1")]
        [InlineData(@"6 1
1 6 1 2 0 4", @"11")]
        [InlineData(@"5 9
3 1 4 1 5", @"0")]
        [InlineData(@"2 0
5 5", @"10")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 2", @"10")]
        [InlineData(@"200000 1000000000", @"607923868")]
        [InlineData(@"15 6", @"22583772")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1
1000000000", @"999999993")]
        [InlineData(@"2
5 8", @"124")]
        [InlineData(@"5
52 67 72 25 79", @"269312")]
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
