using System;
using Xunit;
using AtCoderBeginnerContest135.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest135.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"2 16", @"9")]
        [InlineData(@"0 3", @"IMPOSSIBLE")]
        [InlineData(@"998244353 99824435", @"549034394")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
5 2 3 4 1", @"YES")]
        [InlineData(@"5
2 4 3 5 1", @"NO")]
        [InlineData(@"7
1 2 3 4 5 6 7", @"YES")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
3 5 2
4 5", @"9")]
        [InlineData(@"3
5 6 3 8
5 100 8", @"22")]
        [InlineData(@"2
100 1 1
1 100", @"3")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"??2??5", @"768")]
        [InlineData(@"?44", @"1")]
        [InlineData(@"7?4", @"0")]
        [InlineData(@"?6?42???8??2??06243????9??3???7258??5??7???????774????4?1??17???9?5?70???76???", @"153716888")]
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
