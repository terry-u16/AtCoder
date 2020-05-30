using System;
using Xunit;
using Training20200530.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Training20200530.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"3 3
1 2 4
2 3 3
1 3 5", @"7")]
        [InlineData(@"2 2
1 2 1
2 1 1", @"inf")]
        [InlineData(@"6 5
1 2 -1000000000
2 3 -1000000000
3 4 -1000000000
4 5 -1000000000
5 6 -1000000000", @"-5000000000")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3 10
1 2 20
2 3 30
1 3 45", @"35")]
        [InlineData(@"2 2 10
1 2 100
2 2 100", @"-1")]
        [InlineData(@"4 5 10
1 2 1
1 4 1
3 4 1
2 2 100
3 3 100", @"0")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
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
