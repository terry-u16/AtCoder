using System;
using Xunit;
using AtCoderBeginnerContest148.Questions;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderBeginnerContest148.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"3
1", @"2")]
        [InlineData(@"1
2", @"3")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
ip cc", @"icpc")]
        [InlineData(@"8
hmhmnknk uuuuuuuu", @"humuhumunukunuku")]
        [InlineData(@"5
aaaaa aaaaa", @"aaaaaaaaaa")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 3", @"6")]
        [InlineData(@"123 456", @"18696")]
        [InlineData(@"100000 99999", @"9999900000")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
2 1 2", @"1")]
        [InlineData(@"3
2 2 2", @"-1")]
        [InlineData(@"10
3 1 4 1 5 9 2 6 5 3", @"7")]
        [InlineData(@"1
1", @"0")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"12", @"1")]
        [InlineData(@"5", @"0")]
        [InlineData(@"1000000000000000000", @"124999999999999995")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 4 1
1 2
2 3
3 4
3 5", @"2")]
        [InlineData(@"5 4 5
1 2
1 3
1 4
1 5", @"1")]
        [InlineData(@"2 1 2
1 2", @"0")]
        [InlineData(@"9 6 1
1 2
2 3
3 4
4 5
5 6
4 7
7 8
8 9", @"5")]
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
