using System;
using Xunit;
using Training20200609.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Training20200609.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"serval", @"3")]
        [InlineData(@"jackal", @"2")]
        [InlineData(@"zzz", @"0")]
        [InlineData(@"whbrjpjyhsrywlqjxdbrbaomnw", @"8")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"gpg", @"0")]
        [InlineData(@"ggppgggpgg", @"2")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
1 2", @"1 4
5 4")]
        [InlineData(@"3
3 2 1", @"1 2 3
5 3 1")]
        [InlineData(@"3
2 3 1", @"5 10 100
100 10 1")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 1 5 2 4", @"YES")]
        [InlineData(@"4 7 6 4 5", @"NO")]
        [InlineData(@"48792 105960835 681218449 90629745 90632170", @"NO")]
        [InlineData(@"491995 412925347 825318103 59999126 59999339", @"YES")]
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
