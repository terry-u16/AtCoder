using System;
using Xunit;
using Yorukatsu049.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu049.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"3
8 12 40", @"2")]
        [InlineData(@"4
5 6 8 10", @"0")]
        [InlineData(@"6
382253568 723152896 37802240 379425024 404894720 471526144", @"8")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"0011", @"4")]
        [InlineData(@"11011010001011", @"12")]
        [InlineData(@"0", @"0")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
1 2 3 4", @"4 2 1 3")]
        [InlineData(@"3
1 2 3", @"3 1 2")]
        [InlineData(@"1
1000000000", @"1000000000")]
        [InlineData(@"6
0 6 7 6 7 0", @"0 6 6 0 7 7")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 3
1 2 3
0 1 1", @"3
2 2 2 3
1 1 1 2
1 3 1 2")]
        [InlineData(@"3 2
1 0
2 1
1 0", @"3
1 1 1 2
1 2 2 2
3 1 3 2")]
        [InlineData(@"1 5
9 9 9 9 9", @"2
1 1 1 2
1 3 1 4")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"contest
son", @"10")]
        [InlineData(@"contest
programming", @"-1")]
        [InlineData(@"contest
sentence", @"33")]
        [InlineData(@"a
aaa", @"3")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 1", @"Brown")]
        [InlineData(@"5 0", @"Alice")]
        [InlineData(@"0 0", @"Brown")]
        [InlineData(@"4 8", @"Alice")]
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
