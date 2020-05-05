using System;
using Xunit;
using Yorukatsu032.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu032.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"6
khabarovsk 20
moscow 10
kazan 50
kazan 35
moscow 60
khabarovsk 40", @"3
4
6
1
5
2")]
        [InlineData(@"10
yakutsk 10
yakutsk 20
yakutsk 30
yakutsk 40
yakutsk 50
yakutsk 60
yakutsk 70
yakutsk 80
yakutsk 90
yakutsk 100", @"10
9
8
7
6
5
4
3
2
1")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"abaababaab", @"6")]
        [InlineData(@"xxxx", @"2")]
        [InlineData(@"abcabcabcabc", @"6")]
        [InlineData(@"akasakaakasakasakaakas", @"14")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
2 4 4 3", @"4
3
3
4")]
        [InlineData(@"2
1 2", @"2
1")]
        [InlineData(@"6
5 5 4 4 3 3", @"4
4
4
4
4
4")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1
1 1 0 1 0 0 0 1 0 1
3 4 5 6 7 8 9 -2 -3 4 -2", @"8")]
        [InlineData(@"2
1 1 1 1 1 0 0 0 0 0
0 0 0 0 0 1 1 1 1 1
0 -2 -2 -2 -2 -2 -1 -1 -1 -1 -1
0 -2 -2 -2 -2 -2 -1 -1 -1 -1 -1", @"-2")]
        [InlineData(@"3
1 1 1 1 1 1 0 0 1 1
0 1 0 1 1 1 1 0 1 0
1 0 1 1 0 1 0 1 0 1
-8 6 -2 -8 -8 4 8 7 -6 2 2
-9 2 0 1 7 -5 0 -2 -6 5 5
6 -6 7 -9 6 -5 8 0 -9 -7 -7", @"23")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 2
100 50 200", @"1")]
        [InlineData(@"5 8
50 30 40 10 20", @"2")]
        [InlineData(@"10 100
7 10 4 5 9 3 6 8 2 1", @"2")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 6", @"4")]
        [InlineData(@"3 12", @"18")]
        [InlineData(@"100000 1000000000", @"957870001")]
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
