using System;
using Xunit;
using Yorukatsu042.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu042.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"12", @"Yes")]
        [InlineData(@"57", @"No")]
        [InlineData(@"148", @"No")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 5
4 9
2 4", @"12")]
        [InlineData(@"4 30
6 18
2 5
3 10
7 9", @"130")]
        [InlineData(@"1 100000
1000000000 100000", @"100000000000000")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
cbaa
daacc
acacac", @"aac")]
        [InlineData(@"3
a
aa
b", @"")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"aba
4", @"b")]
        [InlineData(@"atcoderandatcodeer
5", @"andat")]
        [InlineData(@"z
1", @"z")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
0 1 3
1 0 2
3 2 0", @"3")]
        [InlineData(@"3
0 1 3
1 0 1
3 1 0", @"-1")]
        [InlineData(@"5
0 21 18 11 28
21 0 13 10 26
18 13 0 23 13
11 10 23 0 17
28 26 13 17 0", @"82")]
        [InlineData(@"3
0 1000000000 1000000000
1000000000 0 1000000000
1000000000 1000000000 0", @"3000000000")]
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
