using System;
using Xunit;
using Yorukatsu044.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu044.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"2 4 6", @"YES")]
        [InlineData(@"2 5 6", @"NO")]
        [InlineData(@"3 2 1", @"YES")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1222", @"1+2+2+2=7")]
        [InlineData(@"0290", @"0-2+9-0=7")]
        [InlineData(@"3242", @"3+2+4-2=7")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 3 1 2", @"3.000000 0")]
        [InlineData(@"2 2 1 1", @"2.000000 1")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 14", @"2")]
        [InlineData(@"10 123", @"3")]
        [InlineData(@"100000 1000000000", @"10000")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"100
1", @"19")]
        [InlineData(@"25
2", @"14")]
        [InlineData(@"314159
2", @"937")]
        [InlineData(@"9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999
3", @"117879300")]
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
