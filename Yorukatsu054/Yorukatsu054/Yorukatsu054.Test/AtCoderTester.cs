using System;
using Xunit;
using Yorukatsu054.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu054.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"7", @"4")]
        [InlineData(@"32", @"32")]
        [InlineData(@"1", @"1")]
        [InlineData(@"100", @"64")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 5 4", @"2")]
        [InlineData(@"2 6 3", @"5")]
        [InlineData(@"31 41 5", @"23")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 2
8 7 6
rsrpr", @"27")]
        [InlineData(@"7 1
100 10 1
ssssppr", @"211")]
        [InlineData(@"30 5
325 234 123
rspsspspsrpspsppprpsprpssprpsr", @"4996")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"12", @"1")]
        [InlineData(@"5", @"0")]
        [InlineData(@"1000000000000000000", @"124999999999999995")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
-2 5 -1", @"2
2 3
3 3")]
        [InlineData(@"2
-1 -3", @"1
2 1")]
        [InlineData(@"5
0 0 0 0 0", @"0")]
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
