using System;
using Xunit;
using Yorukatsu022.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu022.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"8", @"2")]
        [InlineData(@"2", @"0")]
        [InlineData(@"9", @"3")]
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
        [InlineData(@"aca
accc
ca", @"A")]
        [InlineData(@"abcb
aacb
bccc", @"C")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 2
5 1 4
2 3
1 5", @"14")]
        [InlineData(@"10 3
1 8 5 7 100 4 52 33 13 5
3 10
4 30
1 4", @"338")]
        [InlineData(@"3 2
100 100 100
3 99
3 99", @"300")]
        [InlineData(@"11 3
1 1 1 1 1 1 1 1 1 1 1
3 1000000000
4 1000000000
3 1000000000", @"10000000001")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1 2 10 20 15 200", @"110 10")]
        [InlineData(@"1 2 1 2 100 1000", @"200 100")]
        [InlineData(@"17 19 22 26 55 2802", @"2634 934")]
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
