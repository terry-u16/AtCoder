using System;
using Xunit;
using Yorukatsu046.Questions;
using System.Collections.Generic;
using System.Linq;

namespace Yorukatsu046.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"red blue
3 4
red", @"2 4")]
        [InlineData(@"red blue
5 5
blue", @"5 4")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

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
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 2", @"8")]
        [InlineData(@"3 2", @"12")]
        [InlineData(@"1 8", @"0")]
        [InlineData(@"100000 100000", @"530123477")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"?tc????
coder", @"atcoder")]
        [InlineData(@"??p??d??
abc", @"UNRESTORABLE")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 1
1 2 1", @"2")]
        [InlineData(@"6 5
1 2 1
2 3 2
1 3 3
4 5 4
5 6 5", @"2")]
        [InlineData(@"100000 1
1 100000 100", @"99999")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 5 8
1 1
1 4
1 5
2 3
3 1
3 2
3 4
4 4", @"0
0
0
2
4
0
0
0
0
0")]
        [InlineData(@"10 10 20
1 1
1 4
1 9
2 5
3 10
4 2
4 7
5 9
6 4
6 6
6 7
7 1
7 3
7 7
8 1
8 5
8 10
9 2
10 4
10 9", @"4
26
22
10
2
0
0
0
0
0")]
        [InlineData(@"1000000000 1000000000 0", @"999999996000000004
0
0
0
0
0
0
0
0
0")]
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
