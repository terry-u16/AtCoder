using System;
using Xunit;
using Kujikatsu001.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Kujikatsu001.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"1
24 30", @"7")]
        [InlineData(@"2
6 8
3 3", @"4")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 20", @"3")]
        [InlineData(@"25 100", @"3")]
        [InlineData(@"314159265 358979323846264338", @"31")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }
        [Theory]
        [InlineData(@"3
acornistnt
peanutbomb
constraint", @"1")]
        [InlineData(@"2
oneplustwo
ninemodsix", @"0")]
        [InlineData(@"5
abaaaaaaaa
oneplustwo
aaaaaaaaba
twoplusone
aaaabaaaaa", @"4")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 3
-30 -10 10 20 50", @"40")]
        [InlineData(@"3 2
10 20 30", @"20")]
        [InlineData(@"1 1
0", @"0")]
        [InlineData(@"8 5
-9 -7 -4 -3 1 2 3 4", @"10")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
2 3 4", @"13")]
        [InlineData(@"5
12 12 12 12 12", @"5")]
        [InlineData(@"3
1000000 999999 999998", @"996989508")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 3 2
4 3 1 5 2", @"1")]
        [InlineData(@"10 1 6
1 1 2 3 5 8 13 21 34 55", @"7")]
        [InlineData(@"11 7 5
24979445 861648772 623690081 433933447 476190629 262703497 211047202 971407775 628894325 731963982 822804784", @"451211184")]
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
