using System;
using Xunit;
using Yorukatsu056.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu056.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"pot
top", @"YES")]
        [InlineData(@"tab
bet", @"NO")]
        [InlineData(@"eye
eel", @"NO")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1500 2000 1600 3 2", @"7900")]
        [InlineData(@"1500 2000 1900 3 2", @"8500")]
        [InlineData(@"1500 2000 500 90000 100000", @"100000000")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3
1 7 11", @"2")]
        [InlineData(@"3 81
33 105 57", @"24")]
        [InlineData(@"1 1
1000000000", @"999999999")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
6 5 1
1 10 1", @"12
11
0")]
        [InlineData(@"4
12 24 6
52 16 4
99 2 2", @"187
167
101
0")]
        [InlineData(@"4
12 13 1
44 17 17
66 4096 64", @"4162
4162
4162
0")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 2
1 7 2
7 8 1
8 12 1", @"2")]
        [InlineData(@"3 4
1 3 2
3 4 4
1 4 3", @"3")]
        [InlineData(@"9 4
56 60 4
33 37 2
89 90 3
32 43 1
67 68 3
49 51 3
31 32 3
70 71 1
11 12 3", @"2")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 2 2", @"8")]
        [InlineData(@"4 5 4", @"87210")]
        [InlineData(@"100 100 5000", @"817260251")]
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
